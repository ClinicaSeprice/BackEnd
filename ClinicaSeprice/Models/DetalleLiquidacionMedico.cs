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

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal MontoTurno { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal MontoLiquidado { get; set; }

        [ForeignKey("IdLiquidacion")]
        public LiquidacionMedico LiquidacionMedico { get; set; }

        [ForeignKey("IdTurno")]
        public Turno Turno { get; set; }
    }
}
