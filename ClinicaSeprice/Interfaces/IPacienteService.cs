using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Models;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IPacienteService
    {
        Task<bool> RegistrarPacienteAsync(PacienteDTO pacienteDTO);
        Task<IEnumerable<PacienteDTO>> ObtenerPacientePorDniAsync(int dni);
        Task<List<DatosPacientesDTO>> ObtenerPacientesConDatosCompletosAsync();
    }
}
