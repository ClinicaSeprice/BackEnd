namespace ClinicaSepriceAPI.Exceptions
{

    public class HorarioDisponibleException : Exception
    {
        public static readonly string HorarioNoDisponibleConIdMedico = "El horario no fue correctamente registrado";

        public HorarioDisponibleException() : base(HorarioNoDisponibleConIdMedico)
        {
        }

        public HorarioDisponibleException(string message) : base(message)
        {
        }

        public HorarioDisponibleException(string message, Exception inner) : base(message, inner)
        {
        }



    }
}