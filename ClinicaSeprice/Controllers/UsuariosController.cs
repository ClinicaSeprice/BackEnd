using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSepriceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public UsuariosController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Route("Registrar")]
        public IActionResult Registrar(UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var objUsuario= dbContext.Usuarios.FirstOrDefault(p => p.User== usuarioDTO.User);
            if (objUsuario == null) {

            dbContext.Usuarios.Add(new Usuario
            {
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                User = usuarioDTO.User,
                Pass = usuarioDTO.Pass
            });
            dbContext.SaveChanges();
            return Ok("Usuario Registrado Correctamente");
            }
            else
            {
                return BadRequest("El usuario ya existe");
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var usuario = dbContext.Usuarios.FirstOrDefault(p => p.User==loginDTO.User && p.Pass==loginDTO.Pass);
            if (usuario != null) 
            {
                return Ok(usuario);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("GetUsuarios")]
        public IActionResult GetUsuarios()
        {
            return Ok( dbContext.Usuarios.ToList());
        }

        [HttpGet]
        [Route("GetUsuario")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = dbContext.Usuarios.FirstOrDefault(p => p.IdUsuario == id);
            if (usuario != null)
            {
                return Ok(usuario);
            }
            else
            {
                return NoContent();
            }

        }

    }
}
