using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class HorarioDisponible
    {
        [Key]
        public int IdHorario { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan HoraInicio { get; set; } 

        [Required]
        public TimeSpan HoraFin { get; set; }

        public bool Estado { get; set; } = false;

        public bool Baja { get; set; } = false;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public Medico Medico { get; set; }

        public ICollection<Turno> Turnos { get; set; }
    }
}
