using System.ComponentModel.DataAnnotations;

namespace ClinicaSepriceAPI.Models
{
    public class Turno
    {
        [Key]
        public int IdTurno { get; set; }

        [Required]
        public int IdPersona { get; set; }

        [Required]
        public int IdMedico { get; set; }

        [Required]
        public int IdHorario { get; set; }

        public string Motivo { get; set; }

        public string Estado { get; set; }

        public string Notas { get; set; }

        public bool Baja { get; set; } = false;

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public Medico Medico { get; set; }

        public HorarioDisponible HorarioDisponible { get; set; }
        public Persona Persona { get; set; }

        public ICollection<Factura> Facturas { get; set; }
    }
}
