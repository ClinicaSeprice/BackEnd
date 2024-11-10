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
        public async Task<bool> CrearLiquidacionAsync(LiqMedCrearDTO liquidacionDTO)
        {
            var medico = await _appDbContext.Medicos
                .Include(m => m.Persona)
                .FirstOrDefaultAsync(m => m.IdMedico == liquidacionDTO.IdMedico);

            if (medico == null)
            {
                throw new KeyNotFoundException($"No se encontró al médico buscado: {liquidacionDTO.IdMedico}");
            }

            var metodoPago = await _appDbContext.MetodosPago
                .FirstOrDefaultAsync(m => m.IdMetodoPago == liquidacionDTO.IdMetodoPago);

            if(metodoPago == null)
            {
                throw new KeyNotFoundException($"No existe el metodo buscado: {liquidacionDTO.IdMetodoPago}");
            }

            var nuevaLiquidacion = new LiquidacionMedico
            {
                IdMedico = liquidacionDTO.IdMedico,
                Porcentaje = liquidacionDTO.Porcentaje,
                MontoTotal = liquidacionDTO.MontoTotal,
                FechaLiquidacion = DateTime.Now,
                IdMetodoPago = liquidacionDTO.IdMetodoPago,
                NumeroTransaccion = liquidacionDTO.NumeroTransaccion
            };

            await _appDbContext.LiquidacionesMedicos.AddAsync(nuevaLiquidacion);
            await _appDbContext.SaveChangesAsync();

            return true;

        }

        //Metodo para consultar una liquidacion de honorarios a medicos
        //public async Task<List<LiqMedResponseDTO>> ObtenerLiquidacionesAsync()
        //{
        //    var liquidaciones = await _appDbContext.LiquidacionesMedicos
        //        .Select(m => new LiqMedResponseDTO
        //        {
        //            IdLiquidacion = m.IdLiquidacion,
        //            IdMedico = m.IdMedico,
        //            NombreMedico = 

        //        })
        //        .ToListAsync();
        //    return liquidaciones;
        //}
        public async Task<List<LiqMedResponseDTO>> ObtenerLiquidacionAsync()
        {
            var liquidaciones = await _appDbContext.LiquidacionesMedicos
                .Include(l => l.Medico)
                .ThenInclude(m => m.Persona)
                .Include(l => l.MetodoPago)
                .Select(l => new LiqMedResponseDTO
                {
                    IdLiquidacion = l.IdLiquidacion,
                    IdMedico = l.IdMedico,
                    NombreMedico = l.Medico.Persona.Nombre,
                    ApellidoMedico = l.Medico.Persona.Apellido,
                    Especialidad = l.Medico.Especialidad,
                    FechaLiquidacion = l.FechaLiquidacion,
                    Porcentaje = l.Porcentaje,
                    MontoTotal = l.MontoTotal,
                    MetodoDePago = l.MetodoPago.Nombre,
                    //NumeroTransaccion = l.NumeroTransaccion,
                })
                .ToListAsync();

            return liquidaciones;
        }
    }
}
