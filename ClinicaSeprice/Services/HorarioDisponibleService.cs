using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaSepriceAPI.Services
{
    public class HorarioDisponibleService : IHorarioDisponibleService
    {
        private readonly AppDbContext _context;

        public HorarioDisponibleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarHorarioDisponibleDeMedicoAsync(HorarioDisponibleDTO horarioDisponibleDTO)
        {
            // Verificar que el médico existe en la tabla Medicos
            var existeMedico = await _context.Medicos.AnyAsync(m => m.IdMedico == horarioDisponibleDTO.IdMedico);
            if (!existeMedico)
            {
                throw new Exception("El médico especificado no existe.");
            }

            var horarioDisponible = new HorarioDisponible
            {
                IdMedico = horarioDisponibleDTO.IdMedico,
                Fecha = horarioDisponibleDTO.Fecha.Date,
                HoraInicio = TimeSpan.Parse(horarioDisponibleDTO.HoraInicio),
                HoraFin = TimeSpan.Parse(horarioDisponibleDTO.HoraFin),
                Estado = horarioDisponibleDTO.Estado,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };

            _context.HorariosDisponibles.Add(horarioDisponible);
            return await _context.SaveChangesAsync() > 0;
        }



        public async Task<IEnumerable<HorarioDisponibleDTO>> ObtenerHorarioDisponibleDeMedicoAsync(int id)
        {
            return await _context.HorariosDisponibles
                .Where(h => h.IdMedico == id && !h.Baja)
                .Include(h => h.Medico)  // Incluir la entidad Medico
                .Select(h => new HorarioDisponibleDTO
                {
                    IdMedico = h.IdMedico,
                    NombreMedico = h.Medico.Persona.Nombre + " " + h.Medico.Persona.Apellido,  
                    Fecha = h.Fecha,
                    HoraInicio = h.HoraInicio.ToString(@"hh\:mm"), 
                    HoraFin = h.HoraFin.ToString(@"hh\:mm"),
                })
                .ToListAsync();
        }

    }
}
