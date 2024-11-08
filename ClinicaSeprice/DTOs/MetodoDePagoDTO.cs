using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class MetodoDePagoDTO
    {
        public int IdMetodoPago { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public bool Habilitado { get; set; } 
    }
}
