using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface ILiquidacionMedicoService
    {
        Task<bool> RegistrarLiquidacionesMedicosAsync(LiquidacionesMedicosDTO liquidacionesMedicosDTO);
    }
}
