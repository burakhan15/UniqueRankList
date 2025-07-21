using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UniqueRankList.Helper
{
    public static class AesEncryptionHelper
    {
        private static readonly string aesKey = "Th1sIs@VeryStr0ngK3y_32ByteLng!"; // 32 byte = 256 bit
        private static readonly string aesIV = "InitVector16Byte!"; // 16 byte = 128 bit

        public static string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(aesKey);
            aes.IV = Encoding.UTF8.GetBytes(aesIV);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
            using (var sw = new StreamWriter(cs))
            {
                sw.Write(plainText);
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string encryptedText)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(aesKey);
            aes.IV = Encoding.UTF8.GetBytes(aesIV);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var cipherBytes = Convert.FromBase64String(encryptedText);
            using var ms = new MemoryStream(cipherBytes);
            using var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }
    }
}
