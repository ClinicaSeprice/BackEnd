namespace ClinicaSepriceAPI.Execeptions
{
    public class UsuarioExisteException : Exception
    {
        public UsuarioExisteException() : base("El usuario ya existe")
        {

        }
        public UsuarioExisteException(string message) : base(message)
        {

        }
        public UsuarioExisteException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
