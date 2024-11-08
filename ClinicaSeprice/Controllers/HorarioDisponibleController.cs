using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Exceptions; // Asegúrate de importar el namespace de tus excepciones
using Microsoft.AspNetCore.Mvc;
using System;

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

            var (success, errorMessage) = await _horarioService.RegistrarHorarioDisponibleDeMedicoAsync(horarioDto);

            if (!success)
            {
                return BadRequest(new { message = errorMessage });  // Devolver solo el mensaje de error
            }

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
