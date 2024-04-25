using Entities;

namespace Services;

public interface IServUsuario
{
    List<Usuario> BuscarTodos();
    Usuario BuscarPorId(int id);
    Usuario Inserir(Usuario usuario);
    Usuario Editar(int id, Usuario usuario);
    void Remover(int id);
}