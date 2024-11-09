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
                {
                    return StatusCode(500, new
                    {
                        message = "Error al registrar el turno."
                    });
                }
                return Ok(new { message = "Turno registrado con éxito." });                
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

        [HttpPut("AnularTurno/{idTurno}")]
        public async Task<IActionResult> AnularTurno(int idTurno)
        {
            try
            {
                bool result = await _turnoService.AnularTurnoAsync(idTurno);
                if (!result)
                {
                    return StatusCode(500, new
                    {
                        message = "Error al anular el turno."
                    });
                }                   
                return Ok(new { message = "Turno anulado con éxito." });               
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("CambiarPrecio")]
        public async Task<IActionResult> CambiarPrecio([FromBody] PrecioTurnoDTO precioTurnoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                bool result = await _turnoService.CambiarPrecioDeTurnosAsync(precioTurnoDto.NuevoPrecio);
                if (!result)
                {
                    return StatusCode(500, new
                    {
                        message = "Error al cambiar el precio de los turnos."
                    });
                }                   
                return Ok(new { message = "Precio de los turnos actualizado exitosamente." });               
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
