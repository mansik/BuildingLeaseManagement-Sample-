using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BuildingLease.Library
{
    public static class Encrypt
    {
        #region "SHA256 해쉬함수 : 비밀번호는 해쉬값으로 저정해야함."        
        public static string CreateHashBySHA256(string plain)
        {
            byte[] hashValue;
            using (var mySHA256 = SHA256.Create())
            {
                hashValue = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(plain));
            }

            // base64            
            return Convert.ToBase64String(hashValue);
        }
        #endregion

        #region "AES 암호화"        
        /// 주민번호등 개인정보는 AES 암호화함.        
        private static readonly string s_aesKey = "972321625199221207310713420911116187150176184122457316530244110916818369163160134";

        public static string EncryptAES(string plainText)
        {
            string encrypted = string.Empty;
            if (!string.IsNullOrEmpty(plainText))
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(plainText);
                using (Aes encryptor = Aes.Create())
                {
                    var pdb = new Rfc2898DeriveBytes(s_aesKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);

                    using (var MS = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(MS, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                        }
                        encrypted = Convert.ToBase64String(MS.ToArray());
                    }
                }
            }
            return encrypted;
        }

        public static string DecryptAES(string encryptedText)
        {
            string plainText = string.Empty;
            if (!string.IsNullOrEmpty(encryptedText))
            {
                byte[] cipherBytes = Convert.FromBase64String(encryptedText);
                using (Aes encryptor = Aes.Create())
                {
                    var pdb = new Rfc2898DeriveBytes(s_aesKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                        }
                        plainText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            return plainText;
        }
        #endregion
    }
}
