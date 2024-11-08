namespace ClinicaSepriceAPI.Exceptions
{
    public class TurnoException: Exception
    {
        public static readonly string ErrorTurno = "Error en el proceso de turno.";
        public static readonly string PacienteNoExiste = "Paciente no existe.";
        public static readonly string MedicoNoExiste = "Medico ingresado no existe.";
        public static readonly string HorarioNoDisponible = "Horario no disponible.";
        public static readonly string TurnoNoExiste = "El turno no existe.";
        public TurnoException() : base(ErrorTurno)
        {
        }


        public TurnoException(string message) : base(message)
        {
        }

        public TurnoException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
