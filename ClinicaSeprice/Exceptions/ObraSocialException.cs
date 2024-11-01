namespace ClinicaSepriceAPI.Exceptions
{
    
    public class ObraSocialException: Exception
    {
        public static readonly string ObraSocialYaExiste = "La Obra Social ya existe";

        public ObraSocialException() : base(ObraSocialYaExiste)
        {
        }

        public ObraSocialException(string message) : base(message)
        {
        }

        public ObraSocialException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
