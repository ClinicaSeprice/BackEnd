using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Execeptions;
using ClinicaSepriceAPI.Helpers;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaSepriceAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UsuarioService(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        // Método para registrar un nuevo usuario
        public async Task<bool> RegistrarUsuarioAsync(RegistroDto registroDto)
        {
            if (_dbContext.Usuarios.Any(u => u.User == registroDto.User))
                throw new UsuarioExisteException(UsuarioExisteException.UsuarioYaExiste);

            if (_dbContext.Personas.Any(p => p.Dni == registroDto.Dni))
                throw new UsuarioExisteException(UsuarioExisteException.PersonaYaExisteConDNI);

            var nuevaPersona = new Persona
            {
                Nombre = registroDto.Nombre,
                Apellido = registroDto.Apellido,
                Dni = registroDto.Dni,
                Email = registroDto.Email,
                Telefono = registroDto.Telefono,
                FechaNacimiento = registroDto.FechaNacimiento,
                FechaRegistro = DateTime.Now
            };

            // Guarda primero la persona para que se genere el IdPersona
            _dbContext.Personas.Add(nuevaPersona);
            await _dbContext.SaveChangesAsync();

            var nuevoUsuario = new Usuario
            {
                User = registroDto.User,
                Password = PasswordHelper.HashPassword(registroDto.Password),
                Persona = nuevaPersona,
                FechaRegistro = DateTime.Now
            };

            _dbContext.Usuarios.Add(nuevoUsuario);

            var personaRol = new PersonaRol
            {
                IdPersona = nuevaPersona.IdPersona, // Ahora IdPersona tiene un valor generado
                IdRol = 3, // ID predeterminado para el rol
                FechaAlta = DateTime.Now,
                FechaModificacion = DateTime.Now
            };
            _dbContext.PersonaRoles.Add(personaRol);

            await _dbContext.SaveChangesAsync(); // Guarda nuevoUsuario y personaRol
            return true;
        }



        // Método para iniciar sesión
        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var usuario = await _dbContext.Usuarios
                .Include(u => u.Persona)
                .FirstOrDefaultAsync(u => u.User == loginDto.User);

            if (usuario == null || !PasswordHelper.VerifyPassword(loginDto.Password, usuario.Password))
                throw new AutenticacionFallidaException(AutenticacionFallidaException.userPassIncorrecto);

            return TokenHelper.GenerarToken(usuario, _configuration);
        }
    }
}
