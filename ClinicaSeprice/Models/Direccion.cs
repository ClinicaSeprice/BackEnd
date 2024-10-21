using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaSepriceAPI.Models
{
    public class Direccion
    {
        [Key]
        public int IdDireccion { get; set; }

        [Required]
        public int IdPersona { get; set; }

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

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        [ForeignKey("IdPersona")]
        public Persona Persona { get; set; }
    }
}
