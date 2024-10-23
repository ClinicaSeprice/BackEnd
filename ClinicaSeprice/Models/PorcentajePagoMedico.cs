using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class PorcentajePagoMedico
    {
        [Key]
        public int IdPorcentaje { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        public decimal Porcentaje { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        [ForeignKey("IdMedico")]
        public Medico Medico { get; set; }
    }
}
