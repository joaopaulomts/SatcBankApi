using Entities;

namespace Services.DTO;

public class MostrarUsuarioDTO
{
    private int Id { get; set; }
    private string Nome { get; set; }
    private string Cpf { get; set; }
    private decimal Saldo { get; set; }

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

    public static Usuario ToEntity(MostrarUsuarioDTO dto)
    {
        return new Usuario
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Cpf = dto.Cpf,
            Saldo = dto.Saldo
        };
    }
}