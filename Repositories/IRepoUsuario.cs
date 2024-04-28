using Entities;

namespace Repositories;

public interface IRepoUsuario : IRepo<Usuario>
{
    Usuario BuscarPorCpf(string cpf);
}