using System.ComponentModel.DataAnnotations;
using Entities;
using Repositories;
using Services.DTO;

namespace Services;

public class ServUsuario : IServUsuario
{
    private readonly IRepoUsuario _repoUsuario;

    public ServUsuario(IRepoUsuario repoUsuario)
    {
        _repoUsuario = repoUsuario;
    }

    public List<Usuario> BuscarTodos()
    {
        return _repoUsuario.BuscarTodos();
    }

    public Usuario BuscarPorId(int id)
    {
        return _repoUsuario.BuscarPorId(id);
    }

    public Usuario Inserir(Usuario usuario)
    {
        Validar(usuario);

        return _repoUsuario.Inserir(usuario);
    }

    public void Editar(Usuario usuario, EditarUsuarioDTO usuarioNew)
    {
        usuario.Nome = usuarioNew.Nome;
        usuario.Cpf = usuarioNew.Cpf;
        usuario.Senha = usuarioNew.Senha;

        Validar(usuario);

        _repoUsuario.Editar(usuario);
    }

    public void Remover(Usuario usuario)
    {
        _repoUsuario.Remover(usuario);
    }

    public void Transferir(decimal valor, Usuario usuarioOrigem, Usuario usuarioDestino)
    {
        if (usuarioOrigem.Saldo < valor)
        {
            throw new ValidationException("Saldo insuficiente.");
        }

        usuarioOrigem.Saldo = usuarioOrigem.Saldo - valor;
        usuarioDestino.Saldo = usuarioDestino.Saldo + valor;

        _repoUsuario.Editar(usuarioOrigem);
        _repoUsuario.Editar(usuarioDestino);
    }

    public void Depositar(decimal valor, Usuario usuario)
    {
        usuario.Saldo = usuario.Saldo + valor;

        _repoUsuario.Editar(usuario);
    }

    private void Validar(Usuario usuario)
    {
        var usuarioCpfExistente = _repoUsuario.BuscarPorCpf(usuario.Cpf);

        if (usuarioCpfExistente != null && usuarioCpfExistente.Id != usuario.Id)
        {
            throw new ValidationException("Já existe um usuário com este CPF.");
        }

        if (usuario.Senha.Length <= 5)
        {
            throw new ValidationException("A senha deve conter mais de 5 caracteres.");
        }
    }
}
