using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSepriceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorarioDisponibleController : ControllerBase
    {
        private readonly IHorarioDisponibleService _horarioDisponibleService;

        public HorarioDisponibleController(IHorarioDisponibleService horarioDisponibleService)
        {
            _horarioDisponibleService = horarioDisponibleService;
        }

        // Registro de Horario Disponible 

        [HttpPost("altaHorarioDisponibleDeMedico")]
        public async Task<IActionResult> AltaHorarioDisponible([FromBody] HorarioDisponibleDTO horarioDisponibleDTO)
        {
            try
            {
                var registroExitoso = await _horarioDisponibleService.RegistrarHorarioDisponibleDeMedicoAsync(horarioDisponibleDTO);
                if (!registroExitoso)
                {
                    return BadRequest("El registro del horario falló.");
                }
                return Ok("Horario disponible para el profesional registrado exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("buscarHorarioDisponibleDeMedico/{id}")]
        public async Task<IActionResult> ObtenerHorarioDisponibleDeMedico(int id)
        {
            try
            {
                var horarioDisponible = await _horarioDisponibleService.ObtenerHorarioDisponibleDeMedicoAsync(id);
                if (!horarioDisponible?.Any() ?? true)
                {
                    return NotFound($"No hay horarios disponibles para el profesional con ID:  {id}");
                }
                return Ok(horarioDisponible);
            }
            catch
            (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
