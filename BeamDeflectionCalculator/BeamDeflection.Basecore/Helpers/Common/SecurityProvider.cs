using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Basecore.Helpers.Common
{
    public static class SecurityProvider
    {
        public static string GetMD5Hash(this string value)
        {
            string result = string.Empty;
            using (MD5 composer = MD5.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(value);
                result = Convert.ToBase64String(composer.ComputeHash(bytes));
            }
            return result;
        }
        public static string GetSHA256(string value)
        {
            string result = string.Empty;
            using (SHA256 composer = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(value);
                result = Convert.ToBase64String(composer.ComputeHash(bytes));
            }
            return result;
        }
        public static string GetMD5Hash(object input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input.ToString());
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
