namespace ClinicaSepriceAPI.Exceptions
{
    public class UsuarioExisteException : Exception
    {        
        public static readonly string UsuarioYaExiste = "El usuario ya existe";
        public static readonly string PersonaYaExisteConDNI = "Ya existe una persona con este DNI";

        public UsuarioExisteException() : base(UsuarioYaExiste)
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
