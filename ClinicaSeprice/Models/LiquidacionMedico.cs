using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class LiquidacionMedico
    {
        [Key]
        public int IdLiquidacion { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        public DateTime FechaLiquidacion { get; set; } = DateTime.Now;

        public decimal Porcentaje { get; set; }

        public decimal MontoTotal { get; set; }

        [Required]
        public int IdMetodoPago { get; set; } 

        public string NumeroTransaccion { get; set; } 
        [ForeignKey("IdMedico")]
        public Medico Medico { get; set; }

        [ForeignKey("IdMetodoPago")]
        public MetodoPago MetodoPago { get; set; }

        public ICollection<DetalleLiquidacionMedico> Detalles { get; set; }
    }
}
