using System;
using System.Security.Cryptography;

namespace BodegasAburtoWMS.Helpers
{
    public static class PasswordHelper
    {
        private const int SaltSize = 32; // 256 bits
        private const int HashSize = 64; // 512 bits
        private const int Iterations = 100000;

        public static void CrearHash(
            string password,
            out byte[] passwordHash,
            out byte[] passwordSalt)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("La contraseña no puede estar vacía.", nameof(password));
            }

            passwordSalt = RandomNumberGenerator.GetBytes(SaltSize);

            passwordHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                passwordSalt,
                Iterations,
                HashAlgorithmName.SHA512,
                HashSize
            );
        }

        public static bool VerificarPassword(
            string password,
            byte[] passwordHash,
            byte[] passwordSalt)
        {
            // Validaciones de seguridad para evitar excepciones si los bytes son nulos o inválidos
            if (string.IsNullOrEmpty(password) || passwordHash == null || passwordSalt == null)
            {
                return false;
            }

            if (passwordHash.Length != HashSize || passwordSalt.Length != SaltSize)
            {
                return false;
            }

            byte[] nuevoHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                passwordSalt,
                Iterations,
                HashAlgorithmName.SHA512,
                HashSize
            );

            // Comparamos de forma segura contra ataques de tiempo (Timing Attacks)
            return CryptographicOperations.FixedTimeEquals(
                nuevoHash,
                passwordHash
            );
        }
    }
}