namespace ClinicaSepriceAPI.Execeptions
{
    public class UsuarioNoExisteException: Exception
    {
        public UsuarioNoExisteException(): base("El usuario ya existe")
        {
            
        }
        public UsuarioNoExisteException(string message) :base(message)
        {

        }
        public UsuarioNoExisteException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
