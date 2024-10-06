namespace ClinicaSepriceAPI.Execeptions
{
    public class UsuarioNoEncontradoException: Exception
    {
        public UsuarioNoEncontradoException() : base("El usuario no fue encontrado.")
        {

        }
        public UsuarioNoEncontradoException(string mensaje) : base(mensaje)
        {

        }
        public UsuarioNoEncontradoException(string mensaje, Exception inner) : base(mensaje, inner)
        {

        }
    }
}
