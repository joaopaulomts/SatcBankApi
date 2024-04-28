using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;

namespace Presentations.Controllers;

[Route("api/transferencias")]
[ApiController]
public class TransferenciaController : ControllerBase
{
    private readonly IServTransferencia _servTransferencia;

    public TransferenciaController(IServTransferencia servTransferencia)
    {
        _servTransferencia = servTransferencia;
    }

    [HttpPost]
    public IActionResult Inserir([FromBody] InserirTransferenciaDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var transferenciaInserido = _servTransferencia.Inserir(dto);

            return Ok(transferenciaInserido);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult( new { error = e.Message });
        }
    }
}
