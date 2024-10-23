using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class Medico
    {
        [Key]
        public int IdPersona { get; set; }

        [Required]
        [StringLength(100)]
        public string Especialidad { get; set; }

        [Required]
        public int Legajo { get; set; }

        public bool Baja { get; set; } = false;

        public DateTime FechaAlta { get; set; } = DateTime.Now;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public Persona Persona { get; set; }

        public ICollection<HorarioDisponible> HorariosDisponibles { get; set; }

        public ICollection<Turno> Turnos { get; set; }
        public ICollection<PorcentajePagoMedico> Porcentajes { get; set; }

        public ICollection<LiquidacionMedico> Liquidaciones { get; set; }
    }
}
