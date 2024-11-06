using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSepriceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        // Registro de usuario sin dirección obligatoria
        [HttpPost("altaPaciente")]
        public async Task<IActionResult> Register([FromBody] PacienteDTO pacienteDto)
        {
            try
            {
                var registroExitoso = await _pacienteService.RegistrarPacienteAsync(pacienteDto);
                if (!registroExitoso)
                    return BadRequest("El registro de paciente falló.");

                return Ok("Paciente registrado exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("buscarPacientePorDni/{dni}")]
        public async Task<IActionResult> ObtenerPacientePorDni(int dni)
        {
            try
            {
                var pacientes = await _pacienteService.ObtenerPacientePorDniAsync(dni);
                if (!pacientes?.Any() ?? true)
                {
                    return NotFound($"No se encontró ningun paciente con Dni {dni}");
                }
                return Ok(pacientes);
            }
            catch
            (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
