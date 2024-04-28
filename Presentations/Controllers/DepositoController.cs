using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;

namespace Presentations.Controllers;

[Route("api/depositos")]
[ApiController]
public class DepositoController : ControllerBase
{
    private readonly IServDeposito _servDeposito;

    public DepositoController(IServDeposito servDeposito)
    {
        _servDeposito = servDeposito;
    }

    [HttpPost]
    public IActionResult Inserir([FromBody] InserirDepositoDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var depositoInserido = _servDeposito.Inserir(dto);

            return Ok(depositoInserido);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult( new { error = e.Message });
        }
    }
}
