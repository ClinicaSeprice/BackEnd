using ClinicaSepriceAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class PlanObraSocialDTO
    {
        [Required]
        public int IdObraSocial { get; set; }

        [Required]
        [StringLength(100)]
        public string NombrePlan { get; set; }

        public decimal Cobertura { get; set; }

        public bool Baja { get; set; } = false;

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

    }
}
