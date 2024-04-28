using Entities;

namespace Repositories;

public class RepoTransferencia : IRepoTransferencia
{
    private readonly DataContext _dataContext;

    public RepoTransferencia(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Transferencia> BuscarTodos()
    {
        var usuarios = _dataContext.Transferencia.ToList();

        return usuarios;
    }

    public Transferencia BuscarPorId(int id)
    {
        var transferencia = _dataContext.Transferencia.Find(id);

        return transferencia;
    }

    public Transferencia Inserir(Transferencia transferencia)
    {
        _dataContext.Add(transferencia);
        _dataContext.SaveChanges();

        return transferencia;
    }

    public void Editar(Transferencia transferencia)
    {
        _dataContext.SaveChanges();
    }

    public void Remover(Transferencia transferencia)
    {
        _dataContext.Remove(transferencia);
        _dataContext.SaveChanges();
    }
}
