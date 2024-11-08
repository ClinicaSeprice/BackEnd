using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaSepriceAPI.Services
{
    public class HorarioDisponibleService : IHorarioDisponibleService
    {
        private readonly AppDbContext _context;

        public HorarioDisponibleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(bool Success, string ErrorMessage)> RegistrarHorarioDisponibleDeMedicoAsync(HorarioDisponibleDTO horarioDisponibleDTO)
        {
            // Verificar que el médico existe en la tabla Medicos
            var existeMedico = await _context.Medicos.AnyAsync(m => m.IdMedico == horarioDisponibleDTO.IdMedico);
            if (!existeMedico)
            {
                return (false, HorarioDisponibleException.NoExisteMedico);
            }

            // Convertir hora de inicio y fin a TimeSpan
            var horaInicio = TimeSpan.Parse(horarioDisponibleDTO.HoraInicio);
            var horaFin = TimeSpan.Parse(horarioDisponibleDTO.HoraFin);

            // Verificar si el médico ya tiene un horario en el mismo día y que se superponga
            var existeConflicto = await _context.HorariosDisponibles.AnyAsync(h =>
                h.IdMedico == horarioDisponibleDTO.IdMedico &&
                h.Fecha.Date == horarioDisponibleDTO.Fecha.Date &&
                ((horaInicio >= h.HoraInicio && horaInicio < h.HoraFin) ||
                 (horaFin > h.HoraInicio && horaFin <= h.HoraFin) ||
                 (horaInicio <= h.HoraInicio && horaFin >= h.HoraFin))
            );

            if (existeConflicto)
            {
                return (false, HorarioDisponibleException.HorarioExistente);
            }

            // Crear el nuevo horario disponible si no hay conflictos
            var horarioDisponible = new HorarioDisponible
            {
                IdMedico = horarioDisponibleDTO.IdMedico,
                Fecha = horarioDisponibleDTO.Fecha.Date,
                HoraInicio = horaInicio,
                HoraFin = horaFin,
                Estado = horarioDisponibleDTO.Estado,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };

            _context.HorariosDisponibles.Add(horarioDisponible);
            await _context.SaveChangesAsync();

            return (true, string.Empty); // Éxito sin mensaje de error
        }


        public async Task<IEnumerable<HorarioDisponibleDTO>> ObtenerHorarioDisponibleDeMedicoAsync(int id)
        {
            return await _context.HorariosDisponibles
                .Where(h => h.IdMedico == id && !h.Baja)
                .Include(h => h.Medico)
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
