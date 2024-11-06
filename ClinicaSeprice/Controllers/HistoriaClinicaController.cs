using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSepriceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoriaClinicaController : ControllerBase
    {
        private readonly IHistoriaClinicaService _HistoriaClinicaService;

        public HistoriaClinicaController(IHistoriaClinicaService HistoriaClinicaService)
        {
            _HistoriaClinicaService = HistoriaClinicaService;
        }

        // Registro de Historia Clínica 

        [HttpPost("altaHistoriaClinica")]
        public async Task<IActionResult> AltaHistoriaClinica([FromBody] HistoriaClinicaDTO HistoriaClinicaDTO)
        {
            try
            {
                var registroExitoso = await _HistoriaClinicaService.RegistrarHistoriaClinicaAsync(HistoriaClinicaDTO);
                if (!registroExitoso)
                {
                    return BadRequest("El registro de la historia clinica falló.");
                }
                return Ok("Historia clínica registrada exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("buscarHistoriaClinicaPorId/{id}")]
        public async Task<IActionResult> ObtenerHistoriaClinicaPorId(int id)
        {
            try
            {
                var HistoriaClinica = await _HistoriaClinicaService.ObtenerHistoriaClinicaPorIdAsync(id);
                if (!HistoriaClinica?.Any() ?? true)
                {
                    return NotFound($"No se encontró ninguna historia clínica con Id {id}");
                }
                return Ok(HistoriaClinica);
            }
            catch
            (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
