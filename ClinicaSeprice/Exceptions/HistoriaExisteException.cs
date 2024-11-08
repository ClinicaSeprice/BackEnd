namespace ClinicaSepriceAPI.Exceptions
{
    [Serializable]
  public class HistoriaExisteException : Exception
    {
        public static readonly string historiaYaExiste = "La Historia clínica ya existe";

        public HistoriaExisteException() : base(historiaYaExiste)
        {
        }

        public HistoriaExisteException(string message) : base(message)
        {
        }

       
    }
}
