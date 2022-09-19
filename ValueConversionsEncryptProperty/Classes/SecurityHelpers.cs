﻿using System.Security.Cryptography;
using System.Text;

namespace ValueConversionsEncryptProperty.Classes;

public class SecurityHelpers
{
    /// <summary>
    /// Not recommended for a real app
    /// </summary>
    private static string keyString = "E546C8DF278CD5931069B522E695D4F2";
    /// <summary>
    /// Encrypt string using <see cref="keyString"/>
    /// </summary>
    /// <param name="text">text to encrypt</param>
    /// <returns>Encrypted string</returns>
    public static string EncryptString(string text)
    {
        var key = Encoding.UTF8.GetBytes(keyString);

        using (var aesAlg = Aes.Create())
        {
            using (var encryptor = aesAlg.CreateEncryptor(key, aesAlg.IV))
            {
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(text);
                    }

                    var iv = aesAlg.IV;

                    var decryptedContent = msEncrypt.ToArray();

                    var result = new byte[iv.Length + decryptedContent.Length];

                    Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
                    Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

                    return Convert.ToBase64String(result);
                }
            }
        }
    }
    /// <summary>
    /// Decrypt string encryped with <see cref="EncryptString"/> using <see cref="keyString"/>
    /// </summary>
    /// <param name="cipherText">Text to decrypt</param>
    /// <returns>Decrypted string</returns>
    public static string DecryptString(string cipherText)
    {
        var fullCipher = Convert.FromBase64String(cipherText);

        var iv = new byte[16];
        var cipher = new byte[16];

        Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
        Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, iv.Length);
        var key = Encoding.UTF8.GetBytes(keyString);

        using (var aesAlg = Aes.Create())
        {
            using (var decryptor = aesAlg.CreateDecryptor(key, iv))
            {
                string result;
                using (var msDecrypt = new MemoryStream(cipher))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            result = srDecrypt.ReadToEnd();
                        }
                    }
                }

                return result;
            }
        }
    }
}