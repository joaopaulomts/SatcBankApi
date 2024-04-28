using Entities;

namespace Repositories;

public class RepoDepositvo : IRepoDeposito
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
        var deposito = _dataContext.Deposito.Find(id);

        return deposito;
    }

    public Deposito Inserir(Deposito deposito)
    {
        _dataContext.Add(deposito);
        _dataContext.SaveChanges();

        return deposito;
    }

    public void Editar(Deposito deposito)
    {
        _dataContext.SaveChanges();
    }

    public void Remover(Deposito deposito)
    {
        _dataContext.Remove(deposito);
        _dataContext.SaveChanges();
    }
}