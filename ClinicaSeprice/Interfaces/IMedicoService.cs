using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Models;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IMedicoService
    {
        Task<Medico> RegistrarMedicoAsync(MedicoDTO medicoDto);

        Task<List<MedicoHorarioDTO>> ObtenerMedicosAsync();
    }
}
