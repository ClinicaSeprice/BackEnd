using System.Security.Cryptography;
using System.Text;

namespace ClinicaSepriceAPI.Helpers
{
    public static class PasswordHelper
    {
        // Método para hashear la contraseña usando SHA256
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convertir a hexadecimal
                }
                return builder.ToString();
            }
        }

        // Método para verificar si la contraseña ingresada coincide con el hash almacenado
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            var enteredHash = HashPassword(enteredPassword);
            return enteredHash == storedHash;
        }
    }
}
