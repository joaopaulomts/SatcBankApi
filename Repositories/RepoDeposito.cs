using Entities;

namespace Repositories;

public class RepoDepositvo : IRepo<Deposito>
{
    private readonly DataContext _dataContext;

    public RepoDepositvo(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Deposito> BuscarTodos()
    {
        var usuarios = _dataContext.Deposito.ToList();

        return usuarios;
    }

    public Deposito BuscarPorId(int id)
    {
        var deposito = _dataContext.Deposito.Single(p => p.Id == id);

        return deposito;
    }

    public Deposito Inserir(Deposito deposito)
    {
        _dataContext.Add(deposito);
        _dataContext.SaveChanges();

        return deposito;
    }

    public Deposito Editar(Deposito deposito)
    {
        _dataContext.SaveChanges();

        return deposito;
    }

    public void Remover(Deposito deposito)
    {
        _dataContext.Remove(deposito);
        _dataContext.SaveChanges();
    }
}