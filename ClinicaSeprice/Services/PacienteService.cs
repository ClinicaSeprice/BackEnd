using AutoMapper;
using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;

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
                var personaBuscada = await _dbContext.Personas
                    .Where(p => p.Dni == dni).ToListAsync();

                if (personaBuscada == null || !personaBuscada.Any())
                {
                    throw new UsuarioExisteException(UsuarioExisteException.PacienteNoExiste +  dni);
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
                    Direccion = p.Direcciones                        
                        .Select(d => new DireccionDto
                        {
                            Calle = d.Calle,
                            Numero = d.Numero,
                            Complemento = d.Complemento,
                            Ciudad = d.Ciudad,
                            Provincia = d.Provincia,
                            CodigoPostal = d.CodigoPostal
                        })
                        .FirstOrDefault(),
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
