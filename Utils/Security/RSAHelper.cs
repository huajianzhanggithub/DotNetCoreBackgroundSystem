using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Utils.Security
{
    public static class RSAHelper
    {
        public static RSAParameters publicKey { get; private set; }
        public static RSAParameters privateKey { get; private set; }
        public static void InitWindows()
        {
            var parameters = new CspParameters()
            { 
                KeyContainerName = "RSAHELPER" //默认的RSA保存密钥的容器名称}
            };

    }
}
