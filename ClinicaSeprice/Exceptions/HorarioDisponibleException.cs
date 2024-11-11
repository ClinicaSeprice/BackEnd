namespace ClinicaSepriceAPI.Exceptions
{

    public class HorarioDisponibleException : Exception
    {
        public object DataObject { get; }

        public static readonly string HorarioNoDisponibleConIdMedico = "El horario no fue correctamente registrado";
        public static readonly string NoExisteMedico = "El Medico seleccionado no existe.";
        public static readonly string HorarioExistente = "El médico ya tiene un horario asignado que se superpone."
;
        public HorarioDisponibleException() : base(HorarioNoDisponibleConIdMedico)
        {
        }

        public HorarioDisponibleException(string message) : base(message)
        {
        }

        public HorarioDisponibleException(string message, Exception inner) : base(message, inner)
        {
        }

        public HorarioDisponibleException(string message, object dataObject) : base(message)
        {
            DataObject = dataObject;
        }
    }
}