using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Execeptions;
using ClinicaSepriceAPI.Services;
using Microsoft.AspNetCore.Authorization;
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
        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar(UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await usuarioService.RegistrarUsuarioAsync(usuarioDTO);
                return Ok("Usuario Registrado Correctamente");
            }
            catch (UsuarioNoExisteException ex)
            {
                return Conflict(ex.Message);  // 409 Conflict
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al registrar el usuario: " + ex.Message);
            }
        }

        // Inicio de sesión
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var loginResponse = await usuarioService.LoginAsync(loginDTO);
                return Ok(loginResponse);
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

        [Authorize]
        [HttpGet("all")]// Obtener todos los usuarios
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                var usuarios = await usuarioService.ObtenerUsuariosAsync();
                return Ok(usuarios.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error al obtener los usuarios: " + ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{id:int}")]// Obtener un usuario por ID
        public async Task<IActionResult> GetUsuario(int id)
        {
            try
            {
                var usuario = await usuarioService.ObtenerUsuarioPorIdAsync(id);
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado.");
                }
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
