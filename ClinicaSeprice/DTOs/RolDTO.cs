using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class RolDTO
    {
        [Required]
        [MaxLength(50)]
        public string NombreRol { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Baja {  get; set; }
    }
}
