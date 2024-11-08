using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaSepriceAPI.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly AppDbContext _context;

        public TurnoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarTurnoAsync(TurnoDTO turnoDto)
        {
            // Verificar que el paciente existe
            bool existePaciente = await _context.Personas.AnyAsync((Persona p) => p.IdPersona == turnoDto.IdPersona);
            if (!existePaciente)
            {
                throw new TurnoException(TurnoException.PacienteNoExiste);
            }

            bool existeMedico = await _context.Medicos.AnyAsync((Medico m) => m.IdMedico == turnoDto.IdMedico);
            if (!existeMedico)
            {
                throw new TurnoException(TurnoException.MedicoNoExiste);
            }

            HorarioDisponible? horarioDisponible = await _context.HorariosDisponibles.FirstOrDefaultAsync((HorarioDisponible h) => h.IdHorario == turnoDto.IdHorario);

            if (horarioDisponible == null || horarioDisponible.Estado == true)
            {
                throw new TurnoException(TurnoException.HorarioNoDisponible);
            }

            Turno turno = new Turno
            {
                IdPersona = turnoDto.IdPersona,
                IdMedico = turnoDto.IdMedico,
                IdHorario = turnoDto.IdHorario,
                Motivo = turnoDto.Motivo,
                Estado = turnoDto.Estado,
                Notas = turnoDto.Notas,
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now
            };

            _context.Turnos.Add(turno);

            // Actualizar el estado de HorarioDisponible a ocupado
            horarioDisponible.Estado = true;
            _context.HorariosDisponibles.Update(horarioDisponible);

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<IEnumerable<TurnoDetalleDTO>> ObtenerTodosLosTurnosAsync()
        {
            return await _context.Turnos
                .Include(t => t.Persona)  // Incluir datos del paciente
                .Include(t => t.Medico)   // Incluir datos del médico
                .Include(t => t.HorarioDisponible)  // Incluir datos del horario
                .Select(t => new TurnoDetalleDTO
                {
                    // Información del Paciente
                    IdPaciente = t.Persona.IdPersona,
                    NombrePaciente = t.Persona.Nombre,
                    ApellidoPaciente = t.Persona.Apellido,
                    DniPaciente = t.Persona.Dni,
                    //Informacion de turno
                    IdTurno = t.IdTurno,
                    FechaTurno = t.HorarioDisponible.Fecha,
                    Motivo = t.Motivo,
                    Estado = t.Estado,
                    Notas = t.Notas,

                    // Información del Horario
                    FechaHorario = t.HorarioDisponible.Fecha,
                    HoraInicio = t.HorarioDisponible.HoraInicio,
                    HoraFin = t.HorarioDisponible.HoraFin,

                    // Información del Médico
                    IdMedico = t.Medico.IdMedico,
                    NombreMedico = t.Medico.Persona.Nombre,
                    ApellidoMedico= t.Medico.Persona.Apellido,
                    EspecialidadMedico = t.Medico.Especialidad                   
                })
                .ToListAsync();
        }

        public async Task<bool> AnularTurnoAsync(int idTurno)
        {
            
            Turno turno = await _context.Turnos.Include(t => t.HorarioDisponible).FirstOrDefaultAsync(t => t.IdTurno == idTurno);

            if (turno == null)
            {
                throw new TurnoException(TurnoException.TurnoNoExiste);
            }

            if (turno.Estado == "Anulado" || turno.Baja)
            {
                throw new TurnoException(TurnoException.TurnoSeEncuentraAnulado);
            }

            turno.Estado = "Anulado";
            turno.Baja = true;
            turno.FechaModificacion = DateTime.Now;
            
            if (turno.HorarioDisponible != null)
            {
                turno.HorarioDisponible.Estado = false;
                _context.HorariosDisponibles.Update(turno.HorarioDisponible);
            }

            _context.Turnos.Update(turno);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
