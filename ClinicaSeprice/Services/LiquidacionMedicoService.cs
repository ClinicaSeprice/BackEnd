using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

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
        public async Task<bool> RegistrarLiquidacionesMedicosAsync(LiquidacionesMedicosDTO liquidacionesMedicosDTO)
        {
            try
            {
                //validar que el medico exista
                var medico = await _appDbContext.Medicos
                    .FirstOrDefaultAsync(mp => mp.Persona.IdPersona == liquidacionesMedicosDTO.IdMedico);
            }
        }
    }


}
