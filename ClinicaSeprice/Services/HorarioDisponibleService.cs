using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ClinicaSepriceAPI.Services

{
    public class HorarioDisponibleService : IHorarioDisponibleService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public HorarioDisponibleService(AppDbContext dbContext, IConfiguration configuration, IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mapper = mapper;
        }

                 
        public async Task<bool> RegistrarHorarioDisponibleDeMedicoAsync(HorarioDisponibleDTO horarioDisponibleDTO)
        {

            if (_dbContext.HorariosDisponibles.Any(h => h.IdMedico == horarioDisponibleDTO.IdMedico))
            {
                throw new HorarioDisponibleException(HorarioDisponibleException.HorarioNoDisponibleConIdMedico);
            }

            var nuevoHorarioDisponible = new HorarioDisponible
            {
                IdMedico = horarioDisponibleDTO.IdMedico,
                Fecha = horarioDisponibleDTO.Fecha,
                HoraInicio = horarioDisponibleDTO.HoraInicio,
                HoraFin = horarioDisponibleDTO.HoraFin,
                Estado = horarioDisponibleDTO.Estado,
                Baja = horarioDisponibleDTO.Baja,
                FechaCreacion = horarioDisponibleDTO.FechaCreacion,
                FechaModificacion = horarioDisponibleDTO.FechaModificacion

            };

            _ = _dbContext.HorariosDisponibles.Add(nuevoHorarioDisponible);
            _ = await _dbContext.SaveChangesAsync();
            return true;

        }

        //Consultar HorarioDisponible por idMedico

        public async Task<IEnumerable<HorarioDisponibleDTO>> ObtenerHorarioDisponibleDeMedicoAsync(int id)
        {
            try
            {
                var horarioDisponibleDeMedicoConsulta = await _dbContext.HorariosDisponibles.AsNoTracking()
                .Where(h => h.IdMedico == id)
                .ToListAsync();

                if (horarioDisponibleDeMedicoConsulta == null || !horarioDisponibleDeMedicoConsulta.Any())
                {
                    throw new KeyNotFoundException($"No hay horarios disponibles para el médico con ID: {id}");
                }

                IMapper _mapper1 = _mapper;
                return _mapper1.Map<IEnumerable<HorarioDisponibleDTO>>(horarioDisponibleDeMedicoConsulta);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }
}

