using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class PrecioTurno
    {
        [Key]
        public int IdPrecio { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }

        public bool Activo { get; set; } = true;

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public DateTime? FechaModificacion { get; set; }

        public DateTime? FechaBaja { get; set; }
    }
}
