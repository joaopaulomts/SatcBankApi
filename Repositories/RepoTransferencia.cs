using Entities;

namespace Repositories;

public class RepoTransferencia : IRepo<Transferencia>
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
        var transferencia = _dataContext.Transferencia.Single(p => p.Id == id);

        return transferencia;
    }

    public Transferencia Inserir(Transferencia transferencia)
    {
        _dataContext.Add(transferencia);
        _dataContext.SaveChanges();

        return transferencia;
    }

    public Transferencia Editar(Transferencia transferencia)
    {
        _dataContext.SaveChanges();

        return transferencia;
    }

    public void Remover(Transferencia transferencia)
    {
        _dataContext.Remove(transferencia);
        _dataContext.SaveChanges();
    }
}
