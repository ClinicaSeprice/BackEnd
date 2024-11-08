namespace ClinicaSepriceAPI.Execeptions
{
    public class AutenticacionFallidaException : Exception
    {
        public static readonly string userPassIncorrecto = "Usuario o contraseña incorrecta.";
        public AutenticacionFallidaException()
           : base(userPassIncorrecto)
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
