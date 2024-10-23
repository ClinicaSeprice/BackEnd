using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class MetodoPago
    {
        [Key]
        public int IdMetodoPago { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public bool Habilitado { get; set; } = true;
    }
}
