using Entities;
using Services.DTO;

namespace Services;

public interface IServTransferencia
{
    Transferencia Inserir(InserirTransferenciaDTO dto);
}