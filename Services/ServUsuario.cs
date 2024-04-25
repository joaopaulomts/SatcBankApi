using Entities;
using Repositories;

namespace Services;

public class ServUsuario : IServUsuario
{
    private IRepo<Usuario> _repoUsuario;

    public ServUsuario(IRepo<Usuario> repoUsuario)
    {
        _repoUsuario = repoUsuario;
    }

    public List<Usuario> BuscarTodos()
    {
        var usuarios = _repoUsuario.BuscarTodos();
        
        return usuarios;
    }
}