using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;

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
                IdObraSocial = planObraSocialDTO.IdObraSocial,
                NombrePlan = planObraSocialDTO.NombrePlan,
                Cobertura = planObraSocialDTO.Cobertura,
                FechaAlta = DateTime.Now,

            };

            _dbContext.PlanesObraSocial.Add(nuevoPlanObraSocial);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<PlanObraSocialDTO>> ObtenerPlanesPorIdObraSocialAsync(int idObraSocial)
        {
            var planes = await _dbContext.PlanesObraSocial
                .Where(p => p.IdObraSocial == idObraSocial)
                .AsNoTracking()
                .Select(p => new PlanObraSocialDTO
                {
                    IdPlan = p.IdPlan,
                    IdObraSocial = p.IdObraSocial,
                    NombrePlan = p.NombrePlan,
                    Cobertura = p.Cobertura,
                    FechaAlta = p.FechaAlta
                })
                .ToListAsync();

            if (!planes.Any())
            {
                throw new PlanObraSocialException(PlanObraSocialException.PlanObraSocialNoEncontrado, new { idObraSocial });
            }

            return planes;
        }


    }
}
