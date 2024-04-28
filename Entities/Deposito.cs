namespace Entities;

public class Deposito : IEntity
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public Usuario Usuario { get; set; }

    public Deposito()
    {
        Data = DateTime.Now;
    }
}