using Entities;

namespace Repositories;

public class RepoUsuario : IRepo<Usuario>
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

    public Usuario BuscarPorId(int id)
    {
        var usuario = _dataContext.Usuario.Single(p => p.Id == id);

        return usuario;
    }

    public Usuario Inserir(Usuario usuario)
    {
        _dataContext.Add(usuario);
        _dataContext.SaveChanges();

        return usuario;
    }

    public Usuario Editar(Usuario usuario)
    {
        _dataContext.SaveChanges();

        return usuario;
    }

    public void Remover(Usuario usuario)
    {
        _dataContext.Remove(usuario);
        _dataContext.SaveChanges();
    }
}