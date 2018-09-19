using System;
using System.Security.Cryptography;

namespace VoteManager
{
    public static class Utils
    {
        private const int _interations = 10000;

        /// <summary>
        /// Hash and slat the password.
        /// </summary>
        /// <param name="password">Password to be hashed using salt with PBKDF2 algorithm</param>
        public static string GetSaltyPassword(string password, out string saltS)
        {
            var salt = new byte[16];

            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(salt);
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, _interations))
                {
                    // note: 20 must be the max length of the password (max length of the collumn in db)
                    var hash = pbkdf2.GetBytes(20);
                    var hashBytes = new byte[36];

                    Array.Copy(salt, 0, hashBytes, 0, 16); Array.Copy(hash, 0, hashBytes, 16, 20);

                    // TODO: save both hash and salt to the usre's database record.
                    saltS = Convert.ToBase64String(salt);
                    return Convert.ToBase64String(hashBytes); // hashsd password
                                                              // derived from: https://medium.com/@mehanix/lets-talk-security-salted-password-hashing-in-c-5460be5c3aae
                }
            }
        }

        public static string GetHashedPassword(string rawPassword, string salt)
        {
            var saltByte = Convert.FromBase64String(salt);

            using (var pbkdf2 = new Rfc2898DeriveBytes(rawPassword, saltByte, _interations))
            {
                var hash = pbkdf2.GetBytes(20);
                var hashBytes = new byte[36];
                Array.Copy(saltByte, 0, hashBytes, 0, 16); Array.Copy(hash, 0, hashBytes, 16, 20);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}