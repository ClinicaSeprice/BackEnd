namespace ClinicaSepriceAPI.Exceptions
{
    [Serializable]
  public class HistoriaExisteException : Exception
    {
        public object DataObject { get; }

        public static readonly string historiaYaExiste = "La Historia clínica ya existe";

        public HistoriaExisteException() : base(historiaYaExiste)
        {
        }

        public HistoriaExisteException(string message) : base(message)
        {
        }

        public HistoriaExisteException(string message, object dataObject) : base(message)
        {
            DataObject = dataObject;
        }
    }
}
