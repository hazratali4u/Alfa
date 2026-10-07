using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;
namespace SAMSCommon.Classes
{
    public static class Cryptography
    {
        /// <summary>
        /// Author : Syed Fasih-ud-Din
        /// Dated : 15, March 2009  @  12:10
        /// Description : Decrypts Encrypted Text to Original Message
        /// </summary>
        /// <param name="EncryptedText">Encrypted string</param>
        /// <returns></returns>
        public static string Decrypt(string EncryptedText, string Key)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(Key);

            byte[] buffer = Convert.FromBase64String(EncryptedText);
            MemoryStream stream = new MemoryStream();
            try
            {
                DES des = new DESCryptoServiceProvider();
                CryptoStream stream2 = new CryptoStream(stream, des.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
            }
            catch (Exception ex)
            {

            }



            return Encoding.UTF8.GetString(stream.ToArray());
        }

        /// <summary>
        /// Author : Syed Fasih-ud-Din
        /// Dated : 15, March 2009  @  12:10
        /// Description : Encrypts Plain Text to Unreadable Form
        /// </summary>
        /// <param name="PlainText">Plain Text intended to Encrypt</param>
        /// <returns></returns>
        public static string Encrypt(string PlainText, string Key)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Key);
            byte[] rgbIV = Encoding.UTF8.GetBytes(Key);

            byte[] buffer = Encoding.UTF8.GetBytes(PlainText);
            MemoryStream stream = new MemoryStream();
            try
            {
                DES des = new DESCryptoServiceProvider();
                CryptoStream stream2 = new CryptoStream(stream, des.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
            }
            catch (Exception ex)
            {

            }


            return Convert.ToBase64String(stream.ToArray());
        }
    }
}
