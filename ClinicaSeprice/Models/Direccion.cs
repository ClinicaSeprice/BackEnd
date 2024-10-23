using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class Direccion
    {
        [Key]
        public int IdDireccion { get; set; }

        [Required]
        public int IdPersona { get; set; }

        [Required]
        [StringLength(255)]
        public string Calle { get; set; }

        [StringLength(10)]
        public string Numero { get; set; }

        [StringLength(100)]
        public string Complemento { get; set; }

        [StringLength(100)]
        public string Ciudad { get; set; }

        [StringLength(100)]
        public string Provincia { get; set; }

        [StringLength(10)]
        public string CodigoPostal { get; set; }

        public bool Baja { get; set; } = false;

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public Persona Persona { get; set; }
    }
}
