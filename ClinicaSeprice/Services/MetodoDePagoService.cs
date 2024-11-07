using AutoMapper;
using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Models;

namespace ClinicaSepriceAPI.Services
{
    public class MetodoDePagoService : IMetodoDePagosService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public MetodoDePagoService(AppDbContext dbContext, IConfiguration configuration,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        //Metodo para crear un metodo de pago
        public async Task<bool> RegistrarMetodoDePagoAsync(MetodoDePagoDTO metodoDePagoDTO)
        {
            if (_dbContext.MetodosPago.Any(m => m.Nombre == metodoDePagoDTO.Nombre))
            {
                throw new MetodoDePagoException(MetodoDePagoException.MetodoDePagoYaExiste);
            }

            var nuevoMetodoDePago = new MetodoPago
            {
                Nombre = metodoDePagoDTO.Nombre,
            };

            _dbContext.MetodosPago.Add(nuevoMetodoDePago);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
