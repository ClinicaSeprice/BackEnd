using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Models;
using System.Threading.Tasks;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IHistoriaClinicaService
    {
        //Task<bool> ObtenerHistoriaClinicaPorIdAsync(int id);
        Task<HistoriaClinica> ObtenerHistoriaClinicaPorIdAsync(int id);
        Task<bool> RegistrarHistoriaClinicaAsync(HistoriaClinicaDTO historiaClinicaDto);


    }
}
