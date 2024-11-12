using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Helpers;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaSepriceAPI.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public MedicoService(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        // Método para registrar un nuevo medico
        public async Task<Medico> RegistrarMedicoAsync(MedicoDTO medicoDto)
        {
            if (_dbContext.Usuarios.Any(u => u.User == medicoDto.User))
                throw new UsuarioExisteException(UsuarioExisteException.UsuarioYaExiste);

            if (_dbContext.Personas.Any(p => p.Dni == medicoDto.Dni))
                throw new UsuarioExisteException(UsuarioExisteException.PersonaYaExisteConDNI);

            var nuevaPersona = new Persona
            {
                Nombre = medicoDto.Nombre,
                Apellido = medicoDto.Apellido,
                Dni = medicoDto.Dni,
                Email = medicoDto.Email,
                Telefono = medicoDto.Telefono,
                FechaNacimiento = medicoDto.FechaNacimiento,
                FechaRegistro = DateTime.Now
            };

            // Guarda primero la persona para generar el IdPersona
            _dbContext.Personas.Add(nuevaPersona);
            await _dbContext.SaveChangesAsync(); // Genera el IdPersona

            var nuevoUsuario = new Usuario
            {
                User = medicoDto.User,
                Password = PasswordHelper.HashPassword(medicoDto.Password),
                Persona = nuevaPersona,
                FechaRegistro = DateTime.Now
            };

            var nuevoMedico = new Medico
            {
                Legajo = medicoDto.Legajo,
                Especialidad = medicoDto.Especialidad,
                FechaAlta = DateTime.Now,
                Persona = nuevaPersona
            };

            var personaRol = new PersonaRol
            {
                IdPersona = nuevaPersona.IdPersona, // Ahora IdPersona tiene un valor
                IdRol = 2, // ID del rol para médico
                FechaAlta = DateTime.Now,
                FechaModificacion = DateTime.Now
            };

            _dbContext.Usuarios.Add(nuevoUsuario);
            _dbContext.Medicos.Add(nuevoMedico);
            _dbContext.PersonaRoles.Add(personaRol);

            await _dbContext.SaveChangesAsync(); // Guarda nuevoUsuario, nuevoMedico, y personaRol
            return nuevoMedico;
        }



        public async Task<List<MedicoHorarioDTO>> ObtenerMedicosAsync()
        {
            var medicos = await _dbContext.Medicos
                .Select(m => new MedicoHorarioDTO
                {
                    IdMedico = m.IdMedico,
                    Nombre = m.Persona.Nombre,
                    Apellido = m.Persona.Apellido,
                    Dni = m.Persona.Dni,
                    Email = m.Persona.Email,
                    Telefono = m.Persona.Telefono,
                    FechaNacimiento = m.Persona.FechaNacimiento,
                    Legajo = m.Legajo,
                    Especialidad = m.Especialidad,                   
                    HorarioDisponible = m.HorariosDisponibles.Select(h => new HorarioDisponibleDTO
                    {
                        IdHorario = h.IdHorario,
                        Fecha = h.Fecha,
                        HoraInicio = h.HoraInicio.ToString(@"hh\:mm"),
                        HoraFin = h.HoraFin.ToString(@"hh\:mm"),
                        Estado = h.Estado,
                    }).ToList()
                })
                .ToListAsync();

            return medicos;
        }


    }
}
