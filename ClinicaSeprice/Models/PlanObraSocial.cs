using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaSepriceAPI.Models
{
    public class PlanObraSocial
    {
        [Key]
        public int IdPlan { get; set; }

        [Required]
        public int IdObraSocial { get; set; }

        [Required]
        [StringLength(100)]
        public string NombrePlan { get; set; }

        public decimal Cobertura { get; set; }

        [ForeignKey("IdObraSocial")]
        public ObraSocial ObraSocial { get; set; }
    }
}
