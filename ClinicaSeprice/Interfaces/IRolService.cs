using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IRolService
    {
        Task<bool> RegistrarRolAsync(RolDTO rolDTO);
        Task<IEnumerable<RolDTO>> ObtenerRolPorIdAsync(int Id);
    }
}
