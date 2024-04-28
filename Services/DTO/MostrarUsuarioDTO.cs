using Entities;

namespace Services.DTO;

public class MostrarUsuarioDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public decimal Saldo { get; set; }

    public static MostrarUsuarioDTO ToDto(Usuario entity)
    {
        return new MostrarUsuarioDTO
        {
            Id = entity.Id,
            Nome = entity.Nome,
            Cpf = entity.Cpf,
            Saldo = entity.Saldo
        };
    }
}