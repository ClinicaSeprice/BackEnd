using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSepriceAPI.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class PlanObraSocialController : ControllerBase
        {
            private readonly IPlanObraSocialService _planObraSocialService;

            public PlanObraSocialController(IPlanObraSocialService planObraSocialService)
            {
                _planObraSocialService = planObraSocialService;
            }

            // Registro del Plan en la Obra Social 

            [HttpPost("altaPlanObraSocial")]
            public async Task<IActionResult> AltaPlanObraSocial([FromBody] PlanObraSocialDTO planObraSocialDTO)
            {
                try
                {
                    var registroExitoso = await _planObraSocialService.RegistrarPlanObraSocialAsync(planObraSocialDTO);
                    if (!registroExitoso)

                        return BadRequest("El registro del plan en la obra social falló.");

                    return Ok("Plan en Obra Social registrado exitosamente.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    
}
