using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IHistoriaClinicaService
    {
        Task<bool> ObtenerHistoriaClinicaPorIdAsync(int id);
        Task<bool> RegistrarHistoriaClinicaAsync(HistoriaClinicaDTO historiaClinicaDto);


    }
}
