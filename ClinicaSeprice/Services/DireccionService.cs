using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaSepriceAPI.Services
{
    public class DireccionService : IDireccionService
    {
        private readonly AppDbContext _dbContext;

        public DireccionService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AgregarDireccionAsync(int idPersona, DireccionDto direccionDto)
        {
            var persona = await _dbContext.Personas.FindAsync(idPersona);
            if (persona == null) return false;

            var direccion = new Direccion
            {
                IdPersona = idPersona,
                Calle = direccionDto.Calle,
                Numero = direccionDto.Numero,
                Complemento = direccionDto.Complemento,
                Ciudad = direccionDto.Ciudad,
                Provincia = direccionDto.Provincia,
                CodigoPostal = direccionDto.CodigoPostal,
                Baja = direccionDto.Baja
            };

            _dbContext.Direcciones.Add(direccion);
            await _dbContext.SaveChangesAsync();
            return true;
        }             
    }
}
