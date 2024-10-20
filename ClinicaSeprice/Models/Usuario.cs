using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [Required]
        [MaxLength(100)]
        public string User { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        public int? IdPersona { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public bool Baja { get; set; } = false;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;
       
        public Persona Persona { get; set; }
    }
}
