using System;
using System.Security.Cryptography;

namespace EElections.Helpers
{
    public static class PwdUtils
    {
        private const int Interations = 10000;

        /// <summary>
        /// Hash and slat the password.
        /// </summary>
        /// <param name="password">Password to be hashed using salt with PBKDF2 algorithm</param>
        public static (string hashPassword, string salt) GetSaltyPassword(string password)
        {
            byte[] salt = new byte[16];
            using (RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(salt);
                using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, Interations))
                {
                    // NOTE: 20 must be the max length of the password (max length of the collumn in db)
                    byte[] hash = pbkdf2.GetBytes(20);
                    byte[] hashBytes = new byte[36];

                    Array.Copy(salt, 0, hashBytes, 0, 16);
                    Array.Copy(hash, 0, hashBytes, 16, 20);

                    // TODO: save both hash and salt to the usre's database record.
                    string saltS = Convert.ToBase64String(salt);

                    // hashed password
                    // derived from: https://medium.com/@mehanix/lets-talk-security-salted-password-hashing-in-c-5460be5c3aae
                    return (Convert.ToBase64String(hashBytes), saltS);
                }
            }
        }

        public static string GetHashedPassword(string rawPassword, string salt)
        {
            byte[] saltByte = Convert.FromBase64String(salt);
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(rawPassword, saltByte, Interations))
            {
                // rehash the password
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(saltByte, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                return Convert.ToBase64String(hashBytes);
            }
        }

    }
}