using ClinicaSepriceAPI.Models;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();
        Task CrearUsuarioAsync(Usuario usuario);
        Task GuardarCambiosAsync();
    }
}
