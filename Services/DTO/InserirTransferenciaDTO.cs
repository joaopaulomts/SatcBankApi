using Entities;

namespace Services.DTO;

public class InserirTransferenciaDTO
{
    public int UsuarioOrigemId { get; set; }
    public int UsuarioDestinoId { get; set; }
    public decimal Valor { get; set; }

    public static Transferencia ToEntity(InserirTransferenciaDTO dto, Usuario UsuarioOrigem, Usuario UsuarioDestino)
    {
        return new Transferencia
        {
            UsuarioOrigem = UsuarioOrigem,
            UsuarioDestino = UsuarioDestino,
            Valor = dto.Valor,
        };
    }
}