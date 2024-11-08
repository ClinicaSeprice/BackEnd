namespace ClinicaSepriceAPI.Exceptions
{
    public class RolException: Exception
    {
        public static readonly string RolYaExiste = "El rol ya existe";

        public RolException() : base(RolYaExiste)
        {
        }

        public RolException(string message) : base(message)
        {
        }

        public RolException(string message, Exception inner) : base(message, inner)
        {
        }
    }
   
}

