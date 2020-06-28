using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Utils.Security
{
    public static class MD5Helper
    {
        private static MD5 Handler { get; } = new MD5CryptoServiceProvider();
        public static string GetMD5Str(string source)
        {
            var data = Encoding.UTF8.GetBytes(source);
            var security = Handler.ComputeHash(data);
            var sb = new StringBuilder();
            foreach (var item in security)
            {
                sb.Append(item.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
