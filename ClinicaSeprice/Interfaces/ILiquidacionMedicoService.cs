using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface ILiquidacionMedicoService
    {
        Task<bool> CrearLiquidacionAsync(LiqMedCrearDTO liquidacionDTO);
        Task<List<LiqMedResponseDTO>> ObtenerLiquidacionAsync();

    }
}
