using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ClinicaSepriceAPI.Services;

namespace ClinicaSepriceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LiquidacionMedicoController : ControllerBase
    {
        private readonly ILiquidacionMedicoService _liquidacionMedicoService;

        public LiquidacionMedicoController(ILiquidacionMedicoService liquidacionMedicoService)
        {
            _liquidacionMedicoService = liquidacionMedicoService;
        }

        //Creacion de liquidacion de honorarios
        [HttpPost("altaLiquidacion")]
        public async Task<ActionResult<LiqMedResponseDTO>> CrearLiquidacion([FromBody] LiqMedCrearDTO liquidacionDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var resultado = await _liquidacionMedicoService.CrearLiquidacionAsync(liquidacionDTO);

                return Ok(new { message = "Alta liquidacion registrada con éxito" });

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensaje = "Error interno del servidor al procesar la liquidación" });
            }
        }

        //Consultar liquidaciones de honorarios de medicos
        [HttpGet("obtenerLiquidaciones")]
        public async Task<IActionResult> ObtenerLiquidaciones()
        {
            try
            {
                var liquidaciones = await _liquidacionMedicoService.ObtenerLiquidacionAsync();
                return Ok(liquidaciones);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
    }
}
