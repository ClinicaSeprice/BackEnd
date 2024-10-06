using NUnit.Framework;
using System.Security.Cryptography;
using System.Text;

namespace ClinicaSepriceTest
{
    [TestFixture]
    public class PasswordHelperTest
    {
        private string password;
        private string incorrectPassword;
        private string hashedPassword;

        [SetUp]
        public void Setup()
        {
            password = "MiContraseñaSegura";
            incorrectPassword = "OtraContraseña";
            hashedPassword = PasswordHelper.HashPassword(password);
        }

        [Test]
        public void HashPassword_GeneraHashCorrecto_NoEsNuloNiVacio()
        {
            var hashed = PasswordHelper.HashPassword(password);
            Assert.IsNotNull(hashed);
            Assert.IsNotEmpty(hashed);
            Assert.AreNotEqual(password, hashed);
        }

        [Test]
        public void VerifyPassword_ContraseñaCorrecta_RetornaTrue()
        {
            var result = PasswordHelper.VerifyPassword(password, hashedPassword);
            Assert.IsTrue(result);
        }

        [Test]
        public void VerifyPassword_ContraseñaIncorrecta_RetornaFalse()
        {
            var result = PasswordHelper.VerifyPassword(incorrectPassword, hashedPassword);
            Assert.IsFalse(result);
        }

        [Test]
        public void HashPassword_DosContraseñasIguales_RetornanMismoHash()
        {
            var hash2 = PasswordHelper.HashPassword(password);
            Assert.AreEqual(hashedPassword, hash2);
        }

        [Test]
        public void HashPassword_DosContraseñasDiferentes_RetornanHashesDiferentes()
        {
            var hash2 = PasswordHelper.HashPassword(incorrectPassword);
            Assert.AreNotEqual(hashedPassword, hash2);
        }
    }
}
