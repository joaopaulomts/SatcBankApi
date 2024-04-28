using Entities;
using Services.DTO;

namespace Services;

public interface IServDeposito
{
    Deposito Inserir(InserirDepositoDTO dto);
}