using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ClinicaSepriceAPI.Services

{
    public class PacienteService : IPacienteService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PacienteService(AppDbContext dbContext, IConfiguration configuration, 
            IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        // Método para registrar un nuevo paciente
        public async Task<bool> RegistrarPacienteAsync(PacienteDTO pacienteDto)
        {
            if (_dbContext.Personas.Any(p => p.Dni == pacienteDto.Dni))
                throw new UsuarioExisteException(UsuarioExisteException.PacienteYaExisteConDNI);

            var nuevaPersona = new Persona
            {
                Nombre = pacienteDto.Nombre,
                Apellido = pacienteDto.Apellido,
                Dni = pacienteDto.Dni,
                Email = pacienteDto.Email,
                Telefono = pacienteDto.Telefono,
                FechaNacimiento = pacienteDto.FechaNacimiento,
                FechaRegistro = DateTime.Now
            };

            _dbContext.Personas.Add(nuevaPersona);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        //Metodo para consultar paciente por dni
        public async Task<IEnumerable<PacienteDTO>> ObtenerPacientePorDniAsync(int dni)
        {
            try
            {
                var personaBuscada = await _dbContext.Personas.AsNoTracking()
                    .Where(p => p.Dni == dni).ToListAsync();

                if (personaBuscada == null || !personaBuscada.Any())
                {
                    throw new KeyNotFoundException($"No se encontró paciente con DNI: {dni}");
                }
                return _mapper.Map<IEnumerable<PacienteDTO>>(personaBuscada);
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public async Task<List<DatosPacientesDTO>> ObtenerPacientesConDatosCompletosAsync()
        {
            var pacientes = await _dbContext.Personas
                .Include(p => p.Direcciones)
                .Include(p => p.Turnos)
                .ThenInclude(t => t.Facturas)
                .Include(p => p.HistoriaClinica)
                .Select(p => new DatosPacientesDTO
                {
                    Nombre = p.Nombre,
                    Apellido = p.Apellido,
                    Dni = p.Dni,
                    Email = p.Email,
                    Telefono = p.Telefono,
                    FechaNacimiento = p.FechaNacimiento,
                    FechaRegistro = p.FechaRegistro,
                    Direccion = new DireccionDto
                    {
                        Calle = p.Direcciones.FirstOrDefault().Calle,
                        Numero = p.Direcciones.FirstOrDefault().Numero,
                        Complemento = p.Direcciones.FirstOrDefault().Complemento,
                        Ciudad = p.Direcciones.FirstOrDefault().Ciudad,
                        Provincia = p.Direcciones.FirstOrDefault().Provincia,
                        CodigoPostal = p.Direcciones.FirstOrDefault().CodigoPostal
                    },
                    Turnos = p.Turnos.Select(t => new TurnoDTO
                    {
                        Motivo = t.Motivo,
                        PrecioTurno = t.PrecioTurno,
                        Estado = t.Estado,
                        Notas = t.Notas,
                        Facturas = t.Facturas.Select(f => new FacturaDTO
                        {
                            NumeroTransaccion = f.NumeroTransaccion,
                            MontoTotal = f.MontoTotal,
                            MontoPaciente = f.MontoPaciente,
                            FechaPago = f.FechaPago
                        }).ToList()
                    }).ToList(),
                    HistoriaClinica = p.HistoriaClinica != null ? new HistoriaClinicaDTO
                    {
                        IdHistoria = p.HistoriaClinica.IdHistoria,                        
                        Antecedentes = p.HistoriaClinica.Antecedentes,
                        Diagnosticos = p.HistoriaClinica.Diagnosticos,
                        Tratamientos = p.HistoriaClinica.Tratamientos,
                        Peso = p.HistoriaClinica.Peso,
                        Altura = p.HistoriaClinica.Altura,
                        Imc = p.HistoriaClinica.Imc                      
                    } : null
                })
                .ToListAsync();

            return pacientes;
        }

    }
}
