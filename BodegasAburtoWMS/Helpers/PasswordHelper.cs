using System;
using System.Security.Cryptography;

namespace BodegasAburtoWMS.Helpers
{
    public static class PasswordHelper
    {
        private const int SaltSize = 32;
        private const int HashSize = 64;
        private const int Iterations = 100000;

        public static void CrearHash(
            string password,
            out byte[] passwordHash,
            out byte[] passwordSalt)
        {
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
            byte[] nuevoHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                passwordSalt,
                Iterations,
                HashAlgorithmName.SHA512,
                HashSize
            );

            return CryptographicOperations.FixedTimeEquals(
                nuevoHash,
                passwordHash
            );
        }
    }
}