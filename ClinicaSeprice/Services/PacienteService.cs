using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace ClinicaSepriceAPI.Services

{
    public class PacienteService : IPacienteService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public PacienteService(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        // Método para registrar un nuevo paciente
        public async Task<bool> RegistrarPacienteAsync(PacienteDTO pacienteDto)
        {
            if (_dbContext.Personas.Any(p => p.Dni == pacienteDto.Dni))
                throw new UsuarioExisteException(UsuarioExisteException.PacienteYaExisteConDNI);

            var nuevaPersona = new Persona
            {
                Nombre = pacienteDto.Nombre,
                Apellido = pacienteDto.Apellido,
                Dni = pacienteDto.Dni,
                Email = pacienteDto.Email,
                Telefono = pacienteDto.Telefono,
                FechaNacimiento = pacienteDto.FechaNacimiento,
                FechaRegistro = DateTime.Now
            };

            _dbContext.Personas.Add(nuevaPersona);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
