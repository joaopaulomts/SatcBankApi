namespace Repositories;

public interface IRepo<T>
{
    List<T> BuscarTodos();
    T BuscarPorId(int id);
    T Inserir(T entity);
    void Editar(T entity);
    void Remover(T entity);
}