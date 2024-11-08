using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IPlanObraSocialService
    {
        Task<bool> RegistrarPlanObraSocialAsync(PlanObraSocialDTO planObraSocialDTO);
    }
}
