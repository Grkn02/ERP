using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace ERP.Services
{
    public class PasswordManager
    {
        private const int SaltLength = 32; // 32 byte salt length

        public static string HashPassword(string plainTextPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                var salt = GenerateSalt();

                var passwordBytes = Encoding.UTF8.GetBytes(plainTextPassword);
                var saltedPassword = new byte[salt.Length + passwordBytes.Length];
                Buffer.BlockCopy(salt, 0, saltedPassword, 0, salt.Length);
                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, salt.Length, passwordBytes.Length);

                var hash = sha256.ComputeHash(saltedPassword);
                var result = Convert.ToBase64String(hash) + ":" + Convert.ToBase64String(salt);
                return result;
            }
        }

        public static bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            var parts = hashedPassword.Split(':');
            var hash = Convert.FromBase64String(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);

            using (var sha256 = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(plainTextPassword);
                var saltedPassword = new byte[salt.Length + passwordBytes.Length];
                Buffer.BlockCopy(salt, 0, saltedPassword, 0, salt.Length);
                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, salt.Length, passwordBytes.Length);

                var computedHash = sha256.ComputeHash(saltedPassword);
                return AreHashesEqual(hash, computedHash);
            }
        }

        private static byte[] GenerateSalt()
        {

            using (var rng = RandomNumberGenerator.Create())  // Yeni sınıf RandomNumberGenerator
            {
                var salt = new byte[SaltLength];
                rng.GetBytes(salt);  // Salt verisini doldur
                return salt;
            }
        }
            
        

        private static bool AreHashesEqual(byte[] hash1, byte[] hash2)
        {
            if (hash1.Length != hash2.Length)
                return false;

            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i])
                    return false;
            }

            return true;
        }


    }
}
