using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaSepriceAPI.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly AppDbContext _context;

        public FacturaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarFacturaAsync(FacturaDTO facturaDto)
        {
            // Validar que el turno existe
            var turno = await _context.Turnos.FirstOrDefaultAsync(t => t.IdTurno == facturaDto.IdTurno);
            if (turno == null)
            {
                throw new FacturaException(FacturaException.TurnoNoExiste);
            }

            // Validar que el plan de obra social existe
            var planObraSocial = await _context.PlanesObraSocial.FirstOrDefaultAsync(p => p.IdPlan == facturaDto.IdPlanObraSocial);
            if (planObraSocial == null)
            {
                throw new FacturaException(FacturaException.PlanObraSocialNoExiste);
            }

            // Validar que el método de pago existe y está habilitado
            var metodoPago = await _context.MetodosPago.FirstOrDefaultAsync(m => m.IdMetodoPago == facturaDto.IdMetodoPago && m.Habilitado);
            if (metodoPago == null)
            {
                throw new FacturaException(FacturaException.MetodoPagoInvalido);
            }

            // Crear la nueva factura
            var factura = new Factura
            {
                IdTurno = facturaDto.IdTurno,
                IdPlanObraSocial = facturaDto.IdPlanObraSocial,
                IdMetodoPago = facturaDto.IdMetodoPago,
                NumeroTransaccion = facturaDto.NumeroTransaccion,
                MontoTotal = facturaDto.MontoTotal,
                MontoPaciente = facturaDto.MontoPaciente,
                FechaPago = facturaDto.FechaPago
            };

            _context.Facturas.Add(factura);

            turno.Estado = "Pagado";
            turno.FechaModificacion = DateTime.Now;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<FacturaDetalleDTO>> ObtenerTodasLasFacturasDetalladasAsync()
        {
            return await _context.Facturas
                .Include(f => f.Turno)
                .ThenInclude(t => t.Persona)
                .Include(f => f.Turno)
                .ThenInclude(t => t.Medico)
                .ThenInclude(m => m.Persona)
                .Include(f => f.Turno)
                .ThenInclude(t => t.HorarioDisponible)
                .Include(f => f.PlanObraSocial)
                .ThenInclude(po => po.ObraSocial)
                .Include(f => f.MetodoPago)
                .Select(f => new FacturaDetalleDTO
                {
                    // Información de la Factura
                    IdFactura = f.IdFactura,
                    NumeroTransaccion = f.NumeroTransaccion,
                    MontoTotal = f.MontoTotal,
                    MontoPaciente = f.MontoPaciente,
                    FechaPago = f.FechaPago,

                    // Información del Paciente
                    IdPaciente = f.Turno.Persona.IdPersona,
                    NombrePaciente = f.Turno.Persona.Nombre,
                    ApellidoPaciente = f.Turno.Persona.Apellido,
                    DniPaciente = f.Turno.Persona.Dni,

                    // Información del Turno
                    IdTurno = f.Turno.IdTurno,
                    FechaTurno = f.Turno.HorarioDisponible.Fecha,
                    Motivo = f.Turno.Motivo,
                    Estado = f.Turno.Estado,
                    PrecioTurno = f.Turno.PrecioTurno,
                    NotasTurno = f.Turno.Notas,

                    // Información del Horario del Turno
                    FechaHorario = f.Turno.HorarioDisponible.Fecha,
                    HoraInicio = f.Turno.HorarioDisponible.HoraInicio,
                    HoraFin = f.Turno.HorarioDisponible.HoraFin,

                    // Información del Médico
                    IdMedico = f.Turno.Medico.IdMedico,
                    NombreMedico = f.Turno.Medico.Persona.Nombre,
                    ApellidoMedico = f.Turno.Medico.Persona.Apellido,
                    EspecialidadMedico = f.Turno.Medico.Especialidad,

                    // Información de la Obra Social y Plan de Obra Social
                    IdObraSocial = f.PlanObraSocial.ObraSocial.IdObraSocial,
                    NombreObraSocial = f.PlanObraSocial.ObraSocial.Nombre,
                    IdPlanObraSocial = f.PlanObraSocial.IdPlan,
                    NombrePlanObraSocial = f.PlanObraSocial.NombrePlan,
                    Cobertura = f.PlanObraSocial.Cobertura,

                    // Método de Pago
                    IdMetodoPago = f.MetodoPago.IdMetodoPago,
                    NombreMetodoPago = f.MetodoPago.Nombre
                })
                .ToListAsync();
        }
    }
}
