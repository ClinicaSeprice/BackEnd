namespace ClinicaSepriceAPI.Execeptions
{
    public class UsuarioNoEncontradoException : Exception
    {
        public object DataObject { get; }
        public UsuarioNoEncontradoException() : base("El usuario no fue encontrado.")
        {

        }
        public UsuarioNoEncontradoException(string message) : base(message)
        {

        }
        public UsuarioNoEncontradoException(string message, Exception inner) : base(message, inner)
        {

        }

        public UsuarioNoEncontradoException(string message, object dataObject) : base(message)
        {
            DataObject = dataObject;
        }
       
    }
}
