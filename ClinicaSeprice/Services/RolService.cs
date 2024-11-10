using AutoMapper;
using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ClinicaSepriceAPI.Services
{
    public class RolService: IRolService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;   

        public RolService(AppDbContext dbContext, IConfiguration configuration, IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mapper = mapper;
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
        
        //Obtener Rol por id
        public async Task<IEnumerable<RolDTO>> ObtenerRolPorIdAsync(int id)
        {
            try
            {
                var rolBuscado = await _dbContext.Roles.AsNoTracking()
                    .Where(r => r.IdRol == id).ToListAsync();

                if (rolBuscado == null || !rolBuscado.Any())
                {
                    throw new RolException(RolException.RolNoEncontrado + id);
                }
                return _mapper.Map<IEnumerable<RolDTO>>(rolBuscado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}