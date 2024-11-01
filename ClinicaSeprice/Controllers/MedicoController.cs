using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
                var registroExitoso = await _medicoService.RegistrarMedicoAsync(medicoDto);
                if (!registroExitoso)
                    return BadRequest("El registro del médico falló.");

                return Ok("Médico registrado exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
