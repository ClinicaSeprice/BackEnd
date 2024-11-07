using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSepriceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioDisponibleController : ControllerBase
    {
        private readonly IHorarioDisponibleService _horarioService;

        public HorarioDisponibleController(IHorarioDisponibleService horarioService)
        {
            _horarioService = horarioService;
        }

        [HttpPost("RegistarHorarioMedico")]
        public async Task<IActionResult> RegistrarHorarioDisponible([FromBody] HorarioDisponibleDTO horarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _horarioService.RegistrarHorarioDisponibleDeMedicoAsync(horarioDto);
            if (!result)
                return StatusCode(500, "Error al registrar el horario.");

            return Ok("Horario registrado con éxito.");
        }

        [HttpGet("buscarHorariosMedico/{id}")]
        public async Task<IActionResult> ObtenerHorarioDisponibleDeMedico(int id)
        {
            var horarios = await _horarioService.ObtenerHorarioDisponibleDeMedicoAsync(id);
            return Ok(horarios);
        }
    }
}
