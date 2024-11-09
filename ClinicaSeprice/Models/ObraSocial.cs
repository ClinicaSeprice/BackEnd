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

        public long Cuit { get; set; }

        public bool baja { get; set; } = false;

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public ICollection<PlanObraSocial> Planes { get; set; }
    }
}
