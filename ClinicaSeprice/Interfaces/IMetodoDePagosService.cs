using ClinicaSepriceAPI.DTOs;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IMetodoDePagosService
    {
        Task<bool> RegistrarMetodoDePagoAsync(MetodoDePagoDTO metodoDePagoDTO);
    }
}
