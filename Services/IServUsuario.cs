using Entities;
using Services.DTO;

namespace Services;

public interface IServUsuario
{
    List<Usuario> BuscarTodos();
    Usuario BuscarPorId(int id);
    Usuario Inserir(Usuario usuario);
    void Editar(Usuario usuario, EditarUsuarioDTO usuarioNew);
    void Remover(Usuario usuario);
    void Transferir(decimal valor, Usuario usuarioOrigem, Usuario usuarioDestino);
    void Depositar(decimal valor, Usuario usuario);
}