using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IHistoriaClinicaService
    {
        Task<bool> RegistrarHistoriaClinicaAsync(HistoriaClinicaDTO historiaClinicaDto);


    }
}
