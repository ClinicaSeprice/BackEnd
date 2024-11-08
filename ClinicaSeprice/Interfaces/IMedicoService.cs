using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IMedicoService
    {
        Task<bool> RegistrarMedicoAsync(MedicoDTO medicoDto);
       

    }
}
