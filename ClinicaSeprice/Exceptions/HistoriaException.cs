namespace ClinicaSepriceAPI.Exceptions
{
    [Serializable]
  public class HistoriaException : Exception
    {
        public static readonly string historiaYaExiste = "La Historia clínica ya existe";
        public static readonly string historiaNoEncontrada = "No se encontró la historia clínica";

        public HistoriaException() : base(historiaYaExiste) // Constructor por defecto
        {
        }

        public HistoriaException(string message) : base(message) // Constructor con mensaje personalizado
        {
        }

        // Constructor para la excepción específica de historia no encontrada
        public static HistoriaException HistoriaNoEncontrada()
        {
            return new HistoriaException(historiaNoEncontrada);
        }

        // Constructor para la excepción específica de historia ya existente
        public static HistoriaException HistoriaYaExiste()
        {
            return new HistoriaException(historiaYaExiste);
        }


    }
}
