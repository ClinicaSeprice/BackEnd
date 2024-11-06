using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSepriceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObraSocialController: ControllerBase
    {
        private readonly IObraSocialService _obraSocialService;

        public ObraSocialController(IObraSocialService obraSocialService)
        {
            _obraSocialService = obraSocialService;
        }

        // Registro de Obra Social 

        [HttpPost("altaObraSocial")]
        public async Task<IActionResult> AltaObraSocial([FromBody] ObraSocialDTO obraSocialDTO)
        {
            try
            {
                var registroExitoso = await _obraSocialService.RegistrarObraSocialAsync(obraSocialDTO);
                if (!registroExitoso)
                {
                    return BadRequest("El registro de la obra social falló.");
                }
                return Ok("Obra Social registrada exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("buscarObraSocialPorId/{id}")]
        public async Task<IActionResult> ObtenerObraSocialPorId(int id)
        {
            try
            {
                var obraSocial = await _obraSocialService.ObtenerObraSocialPorIdAsync(id);
                if (!obraSocial?.Any() ?? true)
                {
                    return NotFound($"No se encontró ninguna obra social con Id {id}");
                }
                return Ok(obraSocial);
            }
            catch
            (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
