using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Reshare_proto_0._2.Custom_Exceptions;
using Reshare_proto_0._2.Services.Interfaces;

namespace Reshare_proto_0._2.Services
{
    public class EncryptionService : IEncryptionService
    {
        private IConfiguration _config;

        public EncryptionService(IConfiguration config)
        {
            _config = config;
        }

        public string Encrypt(string input)
        {
            byte[] iv = new byte[16];
            byte[] array;
            try
            {
                using (Aes cipher = Aes.Create())
                {
                    cipher.Mode = CipherMode.CBC;
                    cipher.Key = Encoding.UTF8.GetBytes(_config.GetValue<string>("EncryptionKey"));
                    cipher.IV = iv;

                    ICryptoTransform encryptor = cipher.CreateEncryptor(cipher.Key, cipher.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                            {
                                streamWriter.Write(input);
                            }

                            array = memoryStream.ToArray();
                        }
                    }
                }
            }
            catch (OutOfMemoryException oome)
            {
                throw oome;
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
            catch (Exception ex)
            {
                throw new EncryptionException("EncryptionMethod: Something went wrong", ex);
            }

            return Convert.ToBase64String(array);
        }

        public string Decrypt(string encryptedText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(encryptedText);

            try
            {
                using (Aes cipher = Aes.Create())
                {
                    cipher.Mode = CipherMode.CBC;
                    cipher.Key = Encoding.UTF8.GetBytes(_config.GetValue<string>("EncryptionKey"));
                    cipher.IV = iv;
                    ICryptoTransform decryptor = cipher.CreateDecryptor(cipher.Key, cipher.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch(OutOfMemoryException oome)
            {
                throw oome;
            }
            catch(IOException ioe)
            {
                throw ioe;
            }
            catch (Exception e)
            {
                throw new DecryptionException("DecryptionMethod: Something went wrong", e);
            }
        }
    }
}
