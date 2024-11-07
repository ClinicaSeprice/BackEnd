
using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IHorarioDisponibleService
    {
        Task<bool> ObtenerHorarioDisponibleAsync(int id);
        Task<bool> RegistrarHorarioDisponible(HorarioDisponibleDTO horarioDisponibleDTO);

    }
}
