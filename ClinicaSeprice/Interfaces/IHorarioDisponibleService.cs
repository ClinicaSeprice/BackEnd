using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IHorarioDisponibleService
    {
        Task<bool> RegistrarHorarioDisponibleDeMedicoAsync(HorarioDisponibleDTO horarioDisponibleDTO);
        Task<IEnumerable<HorarioDisponibleDTO>> ObtenerHorarioDisponibleDeMedicoAsync(int id);
    }
}
