using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaSepriceAPI.Models
{
    public class PersonaRol
    {
        [Key, Column(Order = 0)]
        public int IdPersona { get; set; }

        [Key, Column(Order = 1)]
        public int IdRol { get; set; }

        public bool Baja { get; set; } = false;

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        [ForeignKey("IdPersona")]
        public Persona Persona { get; set; }

        [ForeignKey("IdRol")]
        public Rol Rol { get; set; }
    }
}
