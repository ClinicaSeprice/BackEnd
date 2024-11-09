using ClinicaSepriceAPI.Data;
using ClinicaSepriceAPI.DTOs;
using ClinicaSepriceAPI.Exceptions;
using ClinicaSepriceAPI.Interfaces;
using ClinicaSepriceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
