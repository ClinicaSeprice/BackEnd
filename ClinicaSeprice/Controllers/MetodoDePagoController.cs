using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSepriceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetodoDePagoController : ControllerBase
    {
        private readonly IMetodoDePagosService _metodoDePagoService;

        public MetodoDePagoController(IMetodoDePagosService metodoDePagosService)
        {
            _metodoDePagoService = metodoDePagosService;
        }

        //Registro del método de pago
        [HttpPost("altaMetodoDePago")]
        public async Task<IActionResult> AltaMetodoDePago([FromBody] MetodoDePagoDTO metodoDePagoDTO)
        {
            try
            {
                var altaMetodoDePagoExitoso = await _metodoDePagoService.RegistrarMetodoDePagoAsync(metodoDePagoDTO);
                if (!altaMetodoDePagoExitoso)
                {
                    return BadRequest("El Alta del metodo de pago falló");
                }
                return Ok("Alta Metodo de Pago registrado con éxito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
