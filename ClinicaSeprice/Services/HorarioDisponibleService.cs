using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ClinicaSepriceAPI.Services

{
    public class HorarioDisponibleService : IHorarioDisponible
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public HorarioDisponibleService(AppDbContext dbContext, IConfiguration configuration, IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        public Task<IEnumerable<HorarioDisponibleDTO>> ObtenerHorarioDisponibleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegistrarHorarioDisponibleAsync(HorarioDisponibleDTO horarioDisponibleDTO)
        {
            throw new NotImplementedException();
        }
    }
}


//        // Método para registrar un nuevo paciente
//        public async Task<bool> RegistrarPacienteAsync(PacienteDTO pacienteDto)
//        {
//            if (_dbContext.Personas.Any(p => p.Dni == pacienteDto.Dni))
//                throw new UsuarioExisteException(UsuarioExisteException.PacienteYaExisteConDNI);

//            var nuevaPersona = new Persona
//            {
//                Nombre = pacienteDto.Nombre,
//                Apellido = pacienteDto.Apellido,
//                Dni = pacienteDto.Dni,
//                Email = pacienteDto.Email,
//                Telefono = pacienteDto.Telefono,
//                FechaNacimiento = pacienteDto.FechaNacimiento,
//                FechaRegistro = DateTime.Now
//            };

//            _dbContext.Personas.Add(nuevaPersona);
//            await _dbContext.SaveChangesAsync();
//            return true;
//        }

//        //Metodo para consultar paciente por dni
//        public async Task<IEnumerable<PacienteDTO>> ObtenerPacientePorDniAsync(int dni)
//        {
//            try
//            {
//                var personaBuscada = await _dbContext.Personas.AsNoTracking()
//                    .Where(p => p.Dni == dni).ToListAsync();

//                if (personaBuscada == null || !personaBuscada.Any())
//                {
//                    throw new KeyNotFoundException($"No se encontró paciente con DNI: {dni}");
//                }
//                return _mapper.Map<IEnumerable<PacienteDTO>>(personaBuscada);
//            }
//            catch (Exception ex)
//            {
//                throw;

//            }
//        }
//    }
//}
