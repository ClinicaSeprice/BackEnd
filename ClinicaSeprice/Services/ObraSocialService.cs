using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;

namespace ClinicaSepriceAPI.Services
{
    public class ObraSocialService: IObraSocialService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public ObraSocialService(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        // Método para registrar una nueva obra social
        public async Task<bool> RegistrarObraSocialAsync(ObraSocialDTO obraSocialDTO)
        {
            if (_dbContext.ObrasSociales.Any(u => u.Nombre == obraSocialDTO.Nombre))
                throw new ObraSocialException(ObraSocialException.ObraSocialYaExiste);

            var nuevaObrasocial = new ObraSocial
            {
                Nombre = obraSocialDTO.Nombre,
                FechaAlta = DateTime.Now,
               

            };

            _dbContext.ObrasSociales.Add(nuevaObrasocial);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}
