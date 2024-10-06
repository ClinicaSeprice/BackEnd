using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Execeptions;
using ClinicaSepriceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSepriceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        // Registro de usuario
        [HttpPost]
        [Route("Registrar")]
        public IActionResult Registrar(UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                usuarioService.RegistrarUsuario(usuarioDTO);
                return Ok("Usuario Registrado Correctamente");
            }
            catch (UsuarioNoExisteException ex)
            {
                return BadRequest(ex.Message);  // Usuario ya existe
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al registrar el usuario: " + ex.Message);
            }
        }

        // Inicio de sesión
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                var usuario = usuarioService.Login(loginDTO);
                return Ok(usuario);
            }
            catch (AutenticacionFallidaException ex)
            {
                return Unauthorized(ex.Message);  
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al iniciar sesión: " + ex.Message);
            }
        }

        // Obtener todos los usuarios
        [HttpGet]
        [Route("GetUsuarios")]
        public IActionResult GetUsuarios()
        {
            try
            {
                var usuarios = usuarioService.ObtenerUsuarios().ToList();
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al obtener los usuarios: " + ex.Message);
            }
        }

        // Obtener un usuario por ID
        [HttpGet]
        [Route("GetUsuario")]
        public IActionResult GetUsuario(int id)
        {
            try
            {
                var usuario = usuarioService.ObtenerUsuarioPorId(id);
                return Ok(usuario);
            }
            catch (UsuarioNoEncontradoException ex)
            {
                return NotFound(ex.Message);  
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al obtener el usuario: " + ex.Message);
            }
        }
    }
}
