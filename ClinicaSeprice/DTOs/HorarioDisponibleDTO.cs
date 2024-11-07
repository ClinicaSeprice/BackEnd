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
        public TimeSpan HoraInicio { get; set; }

        [Required]
        public TimeSpan HoraFin { get; set; }

        public bool Estado { get; set; } = false;

        public bool Baja { get; set; } = false;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime FechaModificacion { get; set; } = DateTime.Now;

        public Medico Medico { get; set; }


    }
}
