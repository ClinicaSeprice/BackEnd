using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicaSepriceAPI.Interfaces
{
    public interface IDireccionService
    {
        Task<bool> AgregarDireccionAsync(int idPersona, DireccionDto direccionDto);        
    }
}
