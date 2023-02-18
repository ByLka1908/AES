using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class CryptographyTools
    {

        public static byte[] EncryptStringToBytes_Aes(string text, byte[] Key, byte[] IV)
        {
            if (text == null || text.Length <= 0)
                throw new ArgumentNullException("Исходный текст");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            byte[] encrypted;
            
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(Key, IV);

                using(MemoryStream msEncrypt = new MemoryStream()) 
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using(StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        public static string DecryptStringToBytes_Aes(byte[] OriginalText, byte[] Key, byte[] IV)
        {
            if (OriginalText == null || OriginalText.Length <= 0)
                throw new ArgumentNullException("Исходный текст");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            string Text;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(Key, IV);

                using (MemoryStream msDencrypt = new MemoryStream(OriginalText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDencrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srEncrypt = new StreamReader(csDecrypt))
                        {
                            Text = srEncrypt.ReadToEnd();
                        }
                        
                    }
                }
            }
            return Text;
        }

        public static string ByteToArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for(i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

    }
}
