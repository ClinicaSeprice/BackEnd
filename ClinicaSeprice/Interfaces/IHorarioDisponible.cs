using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IHorarioDisponible
    {
        Task<bool> RegistrarHorarioDisponibleAsync(HorarioDisponibleDTO horarioDisponibleDTO);
        Task<IEnumerable<HorarioDisponibleDTO>> ObtenerHorarioDisponibleAsync(int id);
    }
}
