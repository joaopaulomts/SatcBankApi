using System.ComponentModel.DataAnnotations;
using Entities;
using Repositories;
using Services.DTO;

namespace Services;

public class ServTransferencia : IServTransferencia
{
    private readonly IRepoTransferencia _repoTransferencia;
    private readonly IServUsuario _servUsuario;

    public ServTransferencia(IRepoTransferencia repoTransferencia, IServUsuario servUsuario)
    {
        _repoTransferencia = repoTransferencia;
        _servUsuario = servUsuario;
    }

    public Transferencia Inserir(InserirTransferenciaDTO dto)
    {
        var validacao = Validar(dto);

        _servUsuario.Transferir(validacao.transferencia.Valor, validacao.usuarioOrigem, validacao.usuarioDestino);

        return _repoTransferencia.Inserir(validacao.transferencia);
    }

    private (Transferencia transferencia, Usuario usuarioOrigem, Usuario usuarioDestino) Validar(InserirTransferenciaDTO dto)
    {
        var usuarioOrigem = _servUsuario.BuscarPorId(dto.UsuarioOrigemId);
        var usuarioDestino = _servUsuario.BuscarPorId(dto.UsuarioDestinoId);

        if (usuarioOrigem == null)
        { 
            throw new ValidationException("O usuário de origem não foi encontrado.");
        }

        if (usuarioDestino == null)
        {
            throw new ValidationException("O usuário de destino não foi encontrado.");
        }

        var transferencia = InserirTransferenciaDTO.ToEntity(dto, usuarioOrigem, usuarioDestino);

        if (transferencia.Valor <= Decimal.Zero)
        {
            throw new ValidationException("O valor deve ser maior que 0.");
        }

        return (transferencia, usuarioOrigem, usuarioDestino);
    }
}