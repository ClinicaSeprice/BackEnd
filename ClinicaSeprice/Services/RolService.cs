using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;

namespace ClinicaSepriceAPI.Services
{
    public class RolService: IRolService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public RolService(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        // Método para registrar un nuevo rol
        public async Task<bool> RegistrarRolAsync(RolDTO rolDto)
        {
            if (_dbContext.Roles.Any(u => u.NombreRol == rolDto.NombreRol))
            {
                throw new RolException(RolException.RolYaExiste);
            }

            var nuevoRol = new Rol
            {
                NombreRol = rolDto.NombreRol,
                FechaAlta = DateTime.Now,
            };

            _dbContext.Roles.Add(nuevoRol);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}