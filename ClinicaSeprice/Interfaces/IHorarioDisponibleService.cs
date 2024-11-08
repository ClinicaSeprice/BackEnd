using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IHorarioDisponibleService
    {
        Task<(bool Success, string ErrorMessage)> RegistrarHorarioDisponibleDeMedicoAsync(HorarioDisponibleDTO horarioDisponibleDTO);
        Task<IEnumerable<HorarioDisponibleDTO>> ObtenerHorarioDisponibleDeMedicoAsync(int id);
    }
}
