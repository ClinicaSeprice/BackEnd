using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ClinicaSepriceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController: ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        // Registro de médico sin dirección obligatoria
        [HttpPost("altaMedico")]
        public async Task<IActionResult> AltaMedico([FromBody] MedicoDTO medicoDto)
        {
            try
            {
                var medicoCreado = await _medicoService.RegistrarMedicoAsync(medicoDto);
                if (medicoCreado == null)
                {
                    return BadRequest(new { message = "El registro del médico falló." });
                }

                // Retornar solo el IdMedico en la respuesta
                return Ok(new
                {                  
                    medicoCreado.IdMedico,
                    message = "Médico registrado exitosamente.",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpGet("obtenerMedicos")]
        public async Task<IActionResult> ObtenerMedicos()
        {
            try
            {
                var medicos = await _medicoService.ObtenerMedicosAsync();
                return Ok(medicos);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

    }
}
