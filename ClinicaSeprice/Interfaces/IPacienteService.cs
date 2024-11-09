using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IPacienteService
    {
        Task<bool> RegistrarPacienteAsync(PacienteDTO pacienteDTO);
        Task<IEnumerable<PacienteDTO>> ObtenerPacientePorDniAsync(int Dni);
        Task<List<DatosPacientesDTO>> ObtenerPacientesConDatosCompletosAsync();
    }
}
