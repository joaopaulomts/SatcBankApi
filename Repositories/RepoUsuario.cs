using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class RepoUsuario : IRepoUsuario
{
    private readonly DataContext _dataContext;

    public RepoUsuario(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Usuario> BuscarTodos()
    {
        var usuarios = _dataContext.Usuario.ToList();

        return usuarios;
    }

    public Usuario BuscarPorCpf(string cpf)
    {
        return _dataContext.Usuario.FirstOrDefault(u => u.Cpf == cpf);
    }

    public Usuario BuscarPorId(int id)
    {
        var usuario = _dataContext.Usuario.Find(id);

        return usuario;
    }

    public Usuario Inserir(Usuario usuario)
    {
        _dataContext.Add(usuario);
        _dataContext.SaveChanges();

        return usuario;
    }

    public void Editar(Usuario usuario)
    {
        _dataContext.Entry(usuario).State = EntityState.Modified;
        _dataContext.SaveChanges();
    }

    public void Remover(Usuario usuario)
    {
        _dataContext.Remove(usuario);
        _dataContext.SaveChanges();
    }
}