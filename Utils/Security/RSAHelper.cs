using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Utils.Security
{
    public static class RSAHelper
    {
        public static RSAParameters PublicKey { get; private set; }
        public static RSAParameters PrivateKey { get; private set; }
        public static void InitWindows()
        {
            var parameters = new CspParameters()
            {
                KeyContainerName = "RSAHELPER" //默认的RSA保存密钥的容器名称}
            };
            var handle = new RSACryptoServiceProvider(parameters);
            PublicKey = handle.ExportParameters(false);
            PrivateKey = handle.ExportParameters(true);
        }

        public static void ExportKeyPair(string publicKeyXmlString, string privateKeyXmlString)
        {
            var handle = new RSACryptoServiceProvider();
            handle.FromXmlString(publicKeyXmlString);
            PublicKey = handle.ExportParameters(false);
            handle.FromXmlString(privateKeyXmlString);
            PrivateKey = handle.ExportParameters(true);
        }

        public static byte[] Encrypt(byte[] dataToEncrypt)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(PublicKey);
                    encryptedData = RSA.Encrypt(dataToEncrypt, true);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static byte[] Decrypt(byte[] dataToDecrypt)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                {
                    rsa.ImportParameters(PrivateKey);
                    decryptedData = rsa.Decrypt(dataToDecrypt, true);
                    return decryptedData;
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
