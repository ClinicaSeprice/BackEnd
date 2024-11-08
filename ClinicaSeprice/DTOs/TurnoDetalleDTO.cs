using System;

namespace ClinicaSepriceAPI.DTOs
{
    public class TurnoDetalleDTO
    {
        // Información del Paciente
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public int DniPaciente { get; set; }

        //Informacion de turno
        public int IdTurno { get; set; }
        public DateTime FechaTurno { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
        public string Notas { get; set; }

        // Información del Horario
        public DateTime FechaHorario { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

        // Información del Médico
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; }
        public string ApellidoMedico { get; set; }
        public string EspecialidadMedico { get; set; }
        
    }
}
