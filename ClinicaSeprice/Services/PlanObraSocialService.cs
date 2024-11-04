using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;

namespace ClinicaSepriceAPI.Services
{
    public class PlanObraSocialService: IPlanObraSocialService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public PlanObraSocialService(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        // Método para registrar un nuevo plan de una obra social
        public async Task<bool> RegistrarPlanObraSocialAsync(PlanObraSocialDTO planObraSocialDTO)
        {
            if (_dbContext.PlanesObraSocial.Any(u => u.NombrePlan == planObraSocialDTO.NombrePlan))
                throw new PlanObraSocialException(PlanObraSocialException.PlanObraSocialYaExiste);

            var nuevoPlanObraSocial = new PlanObraSocial
            {
                NombrePlan = planObraSocialDTO.NombrePlan,
                FechaAlta = DateTime.Now,

            };

            _dbContext.PlanesObraSocial.Add(nuevoPlanObraSocial);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}
