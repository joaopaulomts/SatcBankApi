namespace Entities;

public class Transferencia : IEntity
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public decimal Valor { get; set; }
    public Usuario UsuarioOrigem { get; set; }
    public Usuario UsuarioDestino { get; set; }

    public Transferencia()
    {
        Data = DateTime.Now;
    }
}
