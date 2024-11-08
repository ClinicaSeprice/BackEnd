using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSepriceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoService _turnoService;

        public TurnoController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }

        [HttpPost("RegistrarTurno")]
        public async Task<IActionResult> RegistrarTurno([FromBody] TurnoDTO turnoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                bool result = await _turnoService.RegistrarTurnoAsync(turnoDto);
                if (!result)
                    return StatusCode(500, "Error al registrar el turno.");

                return Ok("Turno registrado con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("ObtenerTodosLosTurnos")]
        public async Task<ActionResult<IEnumerable<TurnoDetalleDTO>>> ObtenerTodosLosTurnos()
        {
            IEnumerable<TurnoDetalleDTO> turnos = await _turnoService.ObtenerTodosLosTurnosAsync();
            return Ok(turnos);
        }

        [HttpDelete("AnularTurno/{idTurno}")]
        public async Task<IActionResult> AnularTurno(int idTurno)
        {
            try
            {
                bool result = await _turnoService.AnularTurnoAsync(idTurno);
                if (!result)
                    return StatusCode(500, "Error al anular el turno.");

                return Ok("Turno anulado con éxito.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
