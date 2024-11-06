using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IPacienteService
    {
        Task<bool> RegistrarPacienteAsync(PacienteDTO pacienteDTO);
        Task<IEnumerable<PacienteDTO>> ObtenerPacientePorDniAsync(int Dni);
        //Task<IEnumerable<PacienteDTO>> ObtenerTodosLosPacientesAsync(bool incluirBajas = false);
        //Task<bool> ActualizarPacienteAsymc(int Dni, PacienteDTO);
        //Task<bool> DarBajaPacienteAsync(int Dni);
       
    }
}
