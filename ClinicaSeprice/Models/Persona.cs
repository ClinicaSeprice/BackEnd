using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class Persona
    {
        public int IdPersona { get; set; }

        [Required]
        public int Dni { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public bool Baja { get; set; } = false;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
        
        public ICollection<Direccion> Direcciones { get; set; }
    }
}
