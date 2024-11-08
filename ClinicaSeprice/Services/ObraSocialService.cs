using AutoMapper;
using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaSepriceAPI.Services
{
    public class ObraSocialService: IObraSocialService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ObraSocialService(AppDbContext dbContext, IConfiguration configuration, IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        // Método para registrar una nueva obra social
        public async Task<bool> RegistrarObraSocialAsync(ObraSocialDTO obraSocialDTO)
        {
            if (_dbContext.ObrasSociales.Any(u => u.Nombre == obraSocialDTO.Nombre))
                throw new ObraSocialException(ObraSocialException.ObraSocialYaExiste);

            var nuevaObrasocial = new ObraSocial
            {
                IdObraSocial = obraSocialDTO.IdObraSocial,
                Nombre = obraSocialDTO.Nombre,
                FechaAlta = DateTime.Now,
            };

            _dbContext.ObrasSociales.Add(nuevaObrasocial);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        //Consultar Obra Social por id
        public async Task<IEnumerable<ObraSocialDTO>> ObtenerObraSocialPorIdAsync(int id)
        {
            try
            {
                var obraSocialConsultada = await _dbContext.ObrasSociales.AsNoTracking()
                    .Where(o => o.IdObraSocial == id)
                    .ToListAsync();

                if (obraSocialConsultada == null || !obraSocialConsultada.Any())
                {
                    throw new KeyNotFoundException($"No se encontró la obra social con Id: {id}");
                }
                return _mapper.Map<IEnumerable<ObraSocialDTO>>(obraSocialConsultada);
            }
            catch (Exception ex) {
                throw;
            }
        }
    }
}
