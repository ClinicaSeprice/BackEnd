using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaSepriceAPI.Models
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }

        [Required]
        public int IdTurno { get; set; }

        [Required]
        public int IdPlanObraSocial { get; set; }

        [Required]
        public int IdMetodoPago { get; set; }

        public string NumeroTransaccion { get; set; }

        public decimal MontoTotal { get; set; }

        public decimal MontoPaciente { get; set; }

        public DateTime FechaPago { get; set; } = DateTime.Now;

        [ForeignKey("IdTurno")]
        public Turno Turno { get; set; }

        [ForeignKey("IdPlanObraSocial")]
        public PlanObraSocial PlanObraSocial { get; set; }

        [ForeignKey("IdMetodoPago")]
        public MetodoPago MetodoPago { get; set; }
    }
}
