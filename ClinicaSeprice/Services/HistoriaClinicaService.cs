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

        public Task<bool> ObtenerHistoriaClinicaPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegistrarHistoriaClinica(HistoriaClinicaDTO historiaClinicaDto)
        {
            throw new NotImplementedException();
        }

        // Método para registrar una nueva HC
        public async Task<bool> RegistrarHistoriaClinicaAsync(HistoriaClinicaDTO historiaClinicaDto)
        {
            if (_dbContext.HistoriasClinicas.Any(u => u.IdHistoria == historiaClinicaDto.IdHistoria))
                throw new HistoriaExisteException(HistoriaExisteException.historiaYaExiste);

         
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
