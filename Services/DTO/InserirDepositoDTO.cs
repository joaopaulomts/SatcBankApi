using System.ComponentModel.DataAnnotations;
using Entities;

namespace Services.DTO;

public class InserirDepositoDTO
{
    public int UsuarioId { get; set; }
    public decimal Valor { get; set; }

    public static Deposito ToEntity(InserirDepositoDTO dto, Usuario usuario)
    {
        return new Deposito
        {
            Usuario = usuario,
            Valor = dto.Valor,
        };
    }
}