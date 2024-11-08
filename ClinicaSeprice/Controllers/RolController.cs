using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaSepriceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        // Registro de rol 

        [HttpPost("altaRol")]
        public async Task<IActionResult> AltaRol([FromBody] RolDTO rolDto)
        {
            try
            {
                var registroExitoso = await _rolService.RegistrarRolAsync(rolDto);
                if (!registroExitoso)
                    return BadRequest("El registro de rol falló.");

                return Ok("Rol registrado exitosamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
