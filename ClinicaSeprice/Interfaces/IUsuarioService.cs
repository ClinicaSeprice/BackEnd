using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> RegistrarUsuarioAsync(RegistroDto registroDto);
        Task<string> LoginAsync(LoginDto loginDto);        
    }
}
