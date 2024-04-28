using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;

namespace Presentations.Controllers;

[Route("api/usuarios")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IServUsuario _servUsuario;

    public UsuarioController(IServUsuario servUsuario)
    {
        _servUsuario = servUsuario;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        try
        {
            var usuarios = _servUsuario.BuscarTodos();
            var dtos = usuarios.Select(usuario => MostrarUsuarioDTO.ToDto(usuario)).ToList();

            return Ok(dtos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Route("/api/usuarios/{id}")]
    [HttpGet]
    public IActionResult BuscarPorId(int id)
    {
        try
        {
            var usuario = _servUsuario.BuscarPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Inserir([FromBody] EditarUsuarioDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var usuario = EditarUsuarioDTO.ToEntity(dto);
            var usuarioInserido = _servUsuario.Inserir(usuario);

            return Ok(usuarioInserido);
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult( new { error = e.Message });
        }
    }

    [Route("/api/usuarios/{id}")]
    [HttpPut]
    public IActionResult Editar(int id, [FromBody] EditarUsuarioDTO usuarioFromBody)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
           var usuario = _servUsuario.BuscarPorId(id);

           if (usuario == null)
           {
               return NotFound();
           }

           _servUsuario.Editar(usuario, usuarioFromBody);

            return Ok();
        }
        catch (Exception e)
        {
            return new BadRequestObjectResult( new { error = e.Message });
        }
    }

    [Route("/api/usuarios/{id}")]
    [HttpDelete]
    public IActionResult Remover(int id)
    {
        try
        {
            var usuario = _servUsuario.BuscarPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _servUsuario.Remover(usuario);

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}