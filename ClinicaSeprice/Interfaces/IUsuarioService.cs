using ClinicaSepriceAPI.DTOs;


namespace ClinicaSepriceAPI.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> RegistrarUsuarioAsync(RegistroDto registroDto);
        Task<string> LoginAsync(LoginDto loginDto);        
    }
}
