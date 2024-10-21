using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }

        [Required]        
        public int DNI { get; set; }

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
        [EmailAddress]
        public string Email { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public bool Baja { get; set; } = false;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public ICollection<Direccion> Direcciones { get; set; }
        public ICollection<PersonaRol> PersonaRoles { get; set; }
        public Medico Medico { get; set; }
        public Personal Personal { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }
        public Usuario Usuario { get; set; }
    }
}
