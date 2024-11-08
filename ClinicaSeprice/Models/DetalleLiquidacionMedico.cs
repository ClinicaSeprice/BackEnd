using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class DetalleLiquidacionMedico
    {
        [Key]
        public int IdDetalle { get; set; }

        [Required]
        public int IdLiquidacion { get; set; }

        [Required]
        public int IdTurno { get; set; }

        public decimal MontoTurno { get; set; }

        public decimal MontoLiquidado { get; set; }

        [ForeignKey("IdLiquidacion")]
        public LiquidacionMedico LiquidacionMedico { get; set; }

        [ForeignKey("IdTurno")]
        public Turno Turno { get; set; }
    }
}
