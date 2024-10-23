using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class ObraSocial
    {
        [Key]
        public int IdObraSocial { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public ICollection<PlanObraSocial> Planes { get; set; }
    }
}
