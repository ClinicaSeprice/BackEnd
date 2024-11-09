using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ClinicaSepriceAPI.Models;


namespace ClinicaSepriceAPI.Services
{
    public class LiquidacionMedicoService : ILiquidacionMedicoService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public LiquidacionMedicoService(AppDbContext appDbContext, IConfiguration configuration, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        //Metodo para registra una liquidacion de honorarios a los medicos
        public async Task<LiqMedCrearDTO> CrearLiquidacionAsync(LiqMedCrearDTO liquidacionDTO)
        {
            var liquidacion = _mapper.Map<LiquidacionMedico>(liquidacionDTO);

            var medico = await _appDbContext.Medicos
                .Include(m => m.Persona)
                .FirstOrDefaultAsync(m => m.IdPersona == liquidacionDTO.IdMedico);

            if (medico == null)
            {
                throw new KeyNotFoundException($"No se encontró al médico buscado: {liquidacionDTO.IdMedico}");
            }

            var metodoPago = await _appDbContext.MetodosPago
                .FirstOrDefaultAsync(m => m.IdMetodoPago == liquidacionDTO.IdMetodoDePago);

            if(metodoPago == null)
            {
                throw new KeyNotFoundException($"No existe el metodo buscado: {liquidacionDTO.IdMetodoDePago}");
            }

            liquidacion.FechaLiquidacion = DateTime.Now;
            liquidacion.Medico = medico;
            liquidacion.MetodoPago = metodoPago;

            await _appDbContext.LiquidacionesMedicos.AddAsync(liquidacion);
            await _appDbContext.SaveChangesAsync();

            return _mapper.Map<LiqMedCrearDTO>(liquidacion);

        }
        
    }


}
