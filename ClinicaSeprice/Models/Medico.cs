using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaSepriceAPI.Models
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }

        [Required]
        public int IdPersona { get; set; }

        [Required]
        [StringLength(100)]
        public string Especialidad { get; set; }

        [Required]
        public int Legajo { get; set; }

        public bool Baja { get; set; } = false;

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        // Propiedad de navegación para la relación con Persona
        [ForeignKey("IdPersona")]
        public Persona Persona { get; set; }

        public ICollection<HorarioDisponible> HorariosDisponibles { get; set; }
        public ICollection<Turno> Turnos { get; set; }
        public ICollection<PorcentajePagoMedico> Porcentajes { get; set; }
        public ICollection<LiquidacionMedico> Liquidaciones { get; set; }
    }
}
