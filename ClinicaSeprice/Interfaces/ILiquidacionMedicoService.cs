using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface ILiquidacionMedicoService
    {
        Task<LiqMedCrearDTO> CrearLiquidacionAsync(LiqMedCrearDTO liquidacionDTO);
        

    }
}
