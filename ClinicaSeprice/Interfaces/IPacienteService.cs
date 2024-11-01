using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IPacienteService
    {
        Task<bool> RegistrarPacienteAsync(PacienteDTO pacienteDTO);
        //Task<bool> ConsultarPacientesAsync(PacienteDTO pacienteDTO);
       
    }
}
