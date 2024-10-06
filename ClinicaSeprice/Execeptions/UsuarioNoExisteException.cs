namespace ClinicaSepriceAPI.Execeptions
{
    public class UsuarioNoExisteException: Exception
    {
        public UsuarioNoExisteException(): base("El usuario ya existe")
        {
            
        }
        public UsuarioNoExisteException(string mensaje):base(mensaje)
        {

        }
        public UsuarioNoExisteException(string mensaje,Exception inner) : base(mensaje, inner)
        {

        }
    }
}
