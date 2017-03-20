using System;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace EnCryptDecrypt
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CryptorEngine
    {
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] key_Array;
            var to_Encrypt_Array = Encoding.UTF8.GetBytes(toEncrypt);

            var settingsReader = new AppSettingsReader();
            // Get the key from config file
            var key = (string) settingsReader.GetValue("SecurityKey", typeof(string));

            if (useHashing)
            {
                var md5_hash = new MD5CryptoServiceProvider();
                key_Array = md5_hash.ComputeHash(Encoding.UTF8.GetBytes(key));
                md5_hash.Clear();
            }
            else
            {
                key_Array = Encoding.UTF8.GetBytes(key);
            }

            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = key_Array,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var crypto_transform = tdes.CreateEncryptor();
            var result_Array = crypto_transform.TransformFinalBlock(to_Encrypt_Array, 0, to_Encrypt_Array.Length);
            tdes.Clear();
            return Convert.ToBase64String(result_Array, 0, result_Array.Length);
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] key_Array;
            var to_Encrypt_Array = Convert.FromBase64String(cipherString);

            var settingsReader = new AppSettingsReader();
            //Get the key from the config file to open the lock
            var key = (string) settingsReader.GetValue("SecurityKey", typeof(string));

            if (useHashing)
            {
                var md5_hash = new MD5CryptoServiceProvider();
                key_Array = md5_hash.ComputeHash(Encoding.UTF8.GetBytes(key));
                md5_hash.Clear();
            }
            else
            {
                key_Array = Encoding.UTF8.GetBytes(key);
            }

            var tdes = new TripleDESCryptoServiceProvider
            {
                Key = key_Array,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var cTransform = tdes.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(to_Encrypt_Array, 0, to_Encrypt_Array.Length);

            tdes.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }
    }
}