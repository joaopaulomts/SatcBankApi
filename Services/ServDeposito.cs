using System.ComponentModel.DataAnnotations;
using Entities;
using Repositories;
using Services.DTO;

namespace Services;

public class ServDeposito : IServDeposito
{
    private readonly IRepoDeposito _repoDeposito;
    private readonly IServUsuario _servUsuario;

    public ServDeposito(IRepoDeposito repoDeposito, IServUsuario servUsuario)
    {
        _repoDeposito = repoDeposito;
        _servUsuario = servUsuario;
    }

    public Deposito Inserir(InserirDepositoDTO dto)
    {
        var validacao = Validar(dto);

        _servUsuario.Depositar(validacao.deposito.Valor, validacao.usuario);

        return _repoDeposito.Inserir(validacao.deposito);
    }

    private (Deposito deposito, Usuario usuario) Validar(InserirDepositoDTO dto)
    {
        var usuario = _servUsuario.BuscarPorId(dto.UsuarioId);

        if (usuario == null)
        {
            throw new ValidationException("O usuário não foi encontrado.");
        }

        var deposito = InserirDepositoDTO.ToEntity(dto, usuario);

        if (deposito.Valor <= Decimal.Zero)
        {
            throw new ValidationException("O valor deve ser maior que 0.");
        }

        return (deposito, usuario);
    }
}
