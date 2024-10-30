using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicaSepriceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DireccionController : ControllerBase
    {
        private readonly IDireccionService _direccionService;

        public DireccionController(IDireccionService direccionService)
        {
            _direccionService = direccionService;
        }

        // Agregar una dirección opcional al usuario
        [HttpPost("{idPersona}")]
        public async Task<IActionResult> AddDireccion(int idPersona, [FromBody] DireccionDto direccionDto)
        {
            var direccionExitosa = await _direccionService.AgregarDireccionAsync(idPersona, direccionDto);
            if (!direccionExitosa) return BadRequest("No se pudo agregar la dirección.");

            return Ok("Dirección agregada exitosamente.");
        }
    }
}
