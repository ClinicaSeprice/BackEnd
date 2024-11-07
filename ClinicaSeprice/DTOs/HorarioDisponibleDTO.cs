using ClinicaSepriceAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.DTOs
{
    public class HorarioDisponibleDTO
    {
        [Required]
        public int IdHorario { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public DateTime HoraInicio { get; set; }

        [Required]
        public DateTime HoraFin { get; set; }

        public bool Estado { get; set; } = false;

        public bool Baja { get; set; } = false;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public Medico Medico { get; set; }

         // Propiedades solo de lectura para el formato de hora
            public string HoraInicioComoString => HoraInicio.ToString("HH:mm");
            public string HoraFinComoString => HoraFin.ToString("HH:mm");
        }


    }
}
