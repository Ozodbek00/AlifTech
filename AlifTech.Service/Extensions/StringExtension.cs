using System.Security.Cryptography;
using System.Text;

namespace AlifTech.Service.Extensions
{
    internal static class StringExtension
    {
        public static string HashPassword(this string password)
        {
            // SHA1 is disposable by inheritance. 
            using var sha1 = SHA1.Create();

            // Send a sample text to hash.  
            var hashedBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Get the hashed string.  
            var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

            return hash;
        }
    }
}
