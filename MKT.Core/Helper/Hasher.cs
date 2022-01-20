using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MKT.Core.Helper
{
    public class Hasher
    {
        public static string EncryptSHA1(string data)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(data)));
        }
        public static bool CheckSha1(string data, string hashedData)
        {
            return hashedData.Equals(EncryptSHA1(data));
        }
    }
}
