namespace ClinicaSepriceAPI.Exceptions
{
    public class PlanObraSocialException: Exception
    {
        public static readonly string PlanObraSocialYaExiste = "El Plan ya existe en la Obra Social.";

        public PlanObraSocialException() : base(PlanObraSocialYaExiste)
        {
        }

        public PlanObraSocialException(string message) : base(message)
        {
        }

        public PlanObraSocialException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
