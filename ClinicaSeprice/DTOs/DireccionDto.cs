using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class DireccionDto
    {
        [Required]
        [MaxLength(255)]
        public string Calle { get; set; }

        [MaxLength(10)]
        public string Numero { get; set; }

        [MaxLength(100)]
        public string Complemento { get; set; }

        [Required]
        [MaxLength(100)]
        public string Ciudad { get; set; }

        [Required]
        [MaxLength(100)]
        public string Provincia { get; set; }

        [MaxLength(10)]
        public string CodigoPostal { get; set; }

        public bool Baja { get; set; } = false;
    }
}
