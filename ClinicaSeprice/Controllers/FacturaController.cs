using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSepriceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpPost("RegistrarFactura")]
        public async Task<IActionResult> RegistrarFactura([FromBody] FacturaDTO facturaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                bool result = await _facturaService.RegistrarFacturaAsync(facturaDto);
                if (!result)
                {
                    return StatusCode(500, FacturaException.ErrorAlRegistrar);
                }
                  
                return Ok(new { message = "Factura registrada con éxito." });
                
            }
            catch (FacturaException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error inesperado: " + ex.Message });
            }
        }
    }
}
