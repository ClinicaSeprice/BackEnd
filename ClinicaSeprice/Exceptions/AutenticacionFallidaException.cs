namespace ClinicaSepriceAPI.Execeptions
{
    public class AutenticacionFallidaException : Exception
    {
        public AutenticacionFallidaException()
           : base("Usuario o contraseña incorrecta.")
        {
        }

        public AutenticacionFallidaException(string message)
            : base(message)
        {
        }

        public AutenticacionFallidaException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
