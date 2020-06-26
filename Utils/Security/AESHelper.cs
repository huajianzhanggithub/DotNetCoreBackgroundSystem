using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Utils.Security
{
    public static class AESHelper
    {
        private static Aes AesHandler { get; }
        static AESHelper()
        {
            AesHandler = Aes.Create();
            AesHandler.Key = Convert.FromBase64String("lB2BxrJdI4UUjK3KEZyQ0obuSgavB1SYJuAFq9oVw0Y=");
            AesHandler.IV = Convert.FromBase64String("6lra6ceX26Fazwj1R4PCOg==");
        }
        public static string Encrypt(string source)
        {
            try
            {
                using (var mem = new MemoryStream())
                {
                    using (var stream = new CryptoStream(mem, AesHandler.CreateEncryptor(AesHandler.Key, AesHandler.IV), CryptoStreamMode.Write))
                    {
                        using (var writer = new StreamWriter(stream))
                        {
                            writer.Write(source);
                        }
                        return Convert.ToBase64String(mem.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public static string Decrypt(string source)
        {
            try
            {
                var data = Convert.FromBase64String(source);
                using (var mem = new MemoryStream(data))
                using (var crypto = new CryptoStream(mem, AesHandler.CreateDecryptor(AesHandler.Key, AesHandler.IV), CryptoStreamMode.Read))
                using (var reader = new StreamReader(crypto))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
