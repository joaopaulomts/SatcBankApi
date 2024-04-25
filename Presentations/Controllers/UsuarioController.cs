using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;

namespace Presentations.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuarioController
    {
        private readonly IServUsuario _servUsuario;

        public UsuarioController(IServUsuario servUsuario)
        {
            _servUsuario = servUsuario;
        }

        [HttpGet]
        public ActionResult BuscarTodos()
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

        [HttpPost]
        public ActionResult Inserir(Usuario usuario)
        {
            try
            {
                _servUsuario.Inserir(usuario);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
