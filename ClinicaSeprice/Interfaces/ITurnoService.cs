using ClinicaSepriceAPI.DTOs;
using System.Threading.Tasks;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface ITurnoService
    {
        Task<bool> RegistrarTurnoAsync(TurnoDTO turnoDto);
        Task<IEnumerable<TurnoDetalleDTO>> ObtenerTodosLosTurnosAsync();
        Task<bool> AnularTurnoAsync(int idTurno);
    }
}
