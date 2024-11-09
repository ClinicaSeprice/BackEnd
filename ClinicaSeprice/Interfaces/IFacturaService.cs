using ClinicaSepriceAPI.DTOs;
using System.Threading.Tasks;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IFacturaService
    {
        Task<bool> RegistrarFacturaAsync(FacturaDTO facturaDto);
        Task<IEnumerable<FacturaDetalleDTO>> ObtenerTodasLasFacturasDetalladasAsync();
    }
}
