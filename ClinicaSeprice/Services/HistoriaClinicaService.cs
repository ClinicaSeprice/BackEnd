using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Helpers;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;

namespace ClinicaSepriceAPI.Services
{
    public class HistoriaClinicaService : IHistoriaClinicaService
    {

        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;


        public HistoriaClinicaService(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<HistoriaClinica> ObtenerHistoriaClinicaPorIdAsync(int id)
        {
            var historiaClinica = await _dbContext.HistoriasClinicas.FindAsync(id);
            if (historiaClinica == null)
            {
                throw new HistoriaException(HistoriaException.historiaNoEncontrada);
            }

            return historiaClinica;
        }




        // Método para registrar una nueva HC
        public async Task<bool> RegistrarHistoriaClinicaAsync(HistoriaClinicaDTO historiaClinicaDto)
        {
            if (_dbContext.HistoriasClinicas.Any(u => u.IdHistoria == historiaClinicaDto.IdHistoria))
                throw new HistoriaException(HistoriaException.historiaYaExiste);

         
            var nuevaHistoriaClinica = new HistoriaClinica
            {
                IdHistoria = historiaClinicaDto.IdHistoria,
                IdPersona = historiaClinicaDto.IdPersona,
                Antecedentes = historiaClinicaDto.Antecedentes,
                Diagnosticos = historiaClinicaDto.Diagnosticos,
                Tratamientos = historiaClinicaDto.Tratamientos,
                Peso = historiaClinicaDto.Peso,
                Altura = historiaClinicaDto.Altura,
                Imc = (decimal)historiaClinicaDto.Imc,
                FechaApertura = historiaClinicaDto.FechaApertura,
                FechaModificacion = (DateTime)historiaClinicaDto.FechaModificacion,
            };


            _dbContext.HistoriasClinicas.Add(nuevaHistoriaClinica);
            await _dbContext.SaveChangesAsync();
            return true;


        }
    }
}
