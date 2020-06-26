using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Utils.Security
{
    public static class DESHelper
    {
        static DESHelper()
        {
            DesHandler = DES.Create("DES");
            DesHandler.Key = Convert.FromBase64String("L1yzjGB2sI4=");
            DesHandler.IV = Convert.FromBase64String("uEcGI4JSAuY=");
        }
        private static DES DesHandler { get; }
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Encrypt(string source)
        {
            try
            {
                using (var memStream = new MemoryStream())
                {
                    using (var cryptStream = new CryptoStream(memStream, DesHandler.CreateEncryptor(DesHandler.Key, DesHandler.IV), CryptoStreamMode.Write))
                    {
                        var bytes = Encoding.UTF8.GetBytes(source);
                        cryptStream.Write(bytes, 0, bytes.Length);
                        cryptStream.FlushFinalBlock();
                        return Convert.ToBase64String(memStream.ToArray());
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return null;
            }
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Decrypt(string source)
        {
            try
            {
                using (var mStream = new MemoryStream(Convert.FromBase64String(source)))
                {
                    using (var cryptoStream=new CryptoStream(mStream,DesHandler.CreateDecryptor(DesHandler.Key,DesHandler.IV),CryptoStreamMode.Read))
                    {
                        using (var reader=new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
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
