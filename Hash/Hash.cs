using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    public static class Hash
    {
        public static string HashPassword(string Password)
        {
            if (Password != "")
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] sourceBytePassw = Encoding.UTF8.GetBytes(Password);
                    byte[] hashSourceBytePassw = sha256Hash.ComputeHash(sourceBytePassw);
                    string HashPassw = BitConverter.ToString(hashSourceBytePassw).Replace("-", String.Empty);
                    return HashPassw;
                }
            }
            else
            {
                return Password;
            }

        }
    }
}
