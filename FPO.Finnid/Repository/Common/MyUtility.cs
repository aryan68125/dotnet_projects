using Dapper;
using finnit;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace finnit
{
    public class MyUtility
    {
        private IHttpContextAccessor _httpContextAccessor;
        public MyUtility(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static object SendSms(string Message, string MobileNo)
        {
            try
            {
                string URL = SmsMaster.Url.ToString();
                URL = URL.Replace("[Message]", Message);
                URL = URL.Replace("[MobileNo]", MobileNo);
                var client = new RestClient(URL);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Cache-Control", "no-cache");
                IRestResponse response = client.Execute(request);
                return new { statusCode = 200, message = "Successfully sent." };
            }
            catch (Exception ex)
            {
                return new { statusCode = 500, message = ex.Message.ToString() };
            }
        }
        public static object SendEmail(string toEmail, string mailSubject, string mailBody)
        {
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            try
            {
                m.From = new MailAddress(EmailMaster.Email.ToString());
                m.To.Add(toEmail);
                m.Subject = mailSubject;
                m.Body = mailBody;
                m.IsBodyHtml = true;
                sc.Host = EmailMaster.HostServer.ToString();
                sc.Port = EmailMaster.Port;
                sc.Credentials = new System.Net.NetworkCredential(EmailMaster.Email.ToString(), EmailMaster.Password.ToString());
                sc.EnableSsl = EmailMaster.EnableSsl;
                sc.Send(m);
                return new { statusCode = 200, message = "Successfully sent." };
            }
            catch (Exception ex)
            {
                return new { statusCode = 500, message = ex.Message.ToString() };
            }
        }
        public static object SendEmailWithFile(string toEmail, string mailSubject, string mailBody, string filename)
        {
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            try
            {
                m.From = new MailAddress(EmailMaster.Email.ToString());
                m.To.Add(toEmail);
                m.Subject = mailSubject;
                m.Body = mailBody;
                m.IsBodyHtml = true;
                m.Attachments.Add(new Attachment(filename));
                sc.Host = EmailMaster.HostServer.ToString();
                sc.Port = EmailMaster.Port;
                sc.Credentials = new System.Net.NetworkCredential(EmailMaster.Email.ToString(), EmailMaster.Password.ToString());
                sc.EnableSsl = EmailMaster.EnableSsl;
                sc.Send(m);
                return new { statusCode = 200, message = "Successfully sent." };
            }
            catch (Exception ex)
            {
                return new { statusCode = 500, message = ex.Message.ToString() };
            }
        }
        public static object SendEmailToAdmin(string mailSubject, string mailBody)
        {
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            try
            {
                m.From = new MailAddress(EmailMaster.Email.ToString());
                m.To.Add("info@qpickservices.com,diptimateconsultants@gmail.com,parijatam.raam@gmail.com");
                m.Subject = mailSubject;
                m.Body = mailBody;
                m.IsBodyHtml = true;
                sc.Host = EmailMaster.HostServer.ToString();
                sc.Port = EmailMaster.Port;
                sc.Credentials = new System.Net.NetworkCredential(EmailMaster.Email.ToString(), EmailMaster.Password.ToString());
                sc.EnableSsl = EmailMaster.EnableSsl;
                sc.Send(m);
                return new { statusCode = 200, message = "Successfully sent." };
            }
            catch (Exception ex)
            {
                return new { statusCode = 500, message = ex.Message.ToString() };
            }
        }
        public static byte[] StringEncode(string text)
        {
            var encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(text);
        }

        /// <summary>
        /// Upload File From Base 64 String
        /// </summary>
        /// <param name="filePath">Folder Path</param>
        /// <param name="base64String">base 64 string</param>
        /// <param name="fileName"> Any File Name</param>
        /// <param name="fileExtention">{.jpg | .png | .pdf}</param>
        /// <returns></returns>
        public static string UploadFile(string filePath, string base64String, string fileName, string fileExtention)
        {
            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                Byte[] byteArray = Convert.FromBase64String(base64String);
                Stream stream = new MemoryStream(byteArray);
                FileStream fileStream = new FileStream(filePath + fileName + fileExtention, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                stream.CopyTo(fileStream);
                stream.Dispose();
                fileStream.Dispose();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }



        private const string SKey = "_?73^?dVT3st5har3";
        private const string SaltKey = "!2S@LT&KT3st5har3EY";
        private const int Iterations = 1042; // Recommendation is >= 1000

        public static void EncryptFile(string srcFilename, string destFilename)
        {
            var aes = new AesManaged();
            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.KeySize = aes.LegalKeySizes[0].MaxSize;
            var salt = Encoding.ASCII.GetBytes(SaltKey);
            var key = new Rfc2898DeriveBytes(SKey, salt, Iterations);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = CipherMode.CBC;
            ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);
            using (var dest = new FileStream(destFilename, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                using (var cryptoStream = new CryptoStream(dest, transform, CryptoStreamMode.Write))
                {
                    using (var source = new FileStream(srcFilename, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        source.CopyTo(cryptoStream);
                    }
                }
            }
        }
    }

    public class Crypt
    {
        private byte[] key;
        private byte[] iv;

        public Crypt()
        {
            this.key = new byte[24]
            {
        (byte) 101,
        (byte) 239,
        (byte) 202,
        (byte) 192,
        (byte) 205,
        (byte) 91,
        (byte) 214,
        (byte) 90,
        byte.MaxValue,
        (byte) 109,
        (byte) 116,
        (byte) 128,
        (byte) 137,
        (byte) 147,
        (byte) 158,
        (byte) 166,
        (byte) 179,
        (byte) 185,
        (byte) 190,
        (byte) 204,
        (byte) 211,
        (byte) 223,
        (byte) 232,
        (byte) 242
            };
            this.iv = new byte[8]
            {
        (byte) 165,
        (byte) 210,
        (byte) 168,
        (byte) 226,
        (byte) 149,
        (byte) 248,
        (byte) 100,
        (byte) 219
            };
        }

        public string Encrypt(string plainText)
        {
            byte[] bytes = new UTF8Encoding().GetBytes(plainText);
            ICryptoTransform encryptor = new TripleDESCryptoServiceProvider().CreateEncryptor(this.key, this.iv);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            memoryStream.Position = 0L;
            byte[] numArray = new byte[checked((int)(memoryStream.Length - 1L) + 1)];
            memoryStream.Read(numArray, 0, checked((int)memoryStream.Length));
            cryptoStream.Close();
            return this.ConvertToString(numArray);
        }

        public string Decrypt(string inputString)
        {
            byte[] byteArray = this.ConvertToByteArray(inputString);
            UTF8Encoding utF8Encoding = new UTF8Encoding();
            ICryptoTransform decryptor = new TripleDESCryptoServiceProvider().CreateDecryptor(this.key, this.iv);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Write);
            cryptoStream.Write(byteArray, 0, byteArray.Length);
            cryptoStream.FlushFinalBlock();
            memoryStream.Position = 0L;
            byte[] numArray = new byte[checked((int)(memoryStream.Length - 1L) + 1)];
            memoryStream.Read(numArray, 0, checked((int)memoryStream.Length));
            cryptoStream.Close();
            return new UTF8Encoding().GetString(numArray);
        }

        private byte[] ConvertToByteArray(string CipherData)
        {
            char[] chArray = new char[checked(CipherData.Length + 1)];
            char[] charArray = CipherData.ToCharArray();
            int num1 = 0;
            int num2 = checked(charArray.Length - 1);
            int index1 = 0;
            while (index1 <= num2)
            {
                if (Operators.CompareString(Conversions.ToString(charArray[index1]), " ", false) == 0)
                    checked { ++num1; }
                checked { ++index1; }
            }
            byte[] numArray = new byte[checked(num1 - 1 + 1)];
            string InputStr = "";
            int index2 = 0;
            int num3 = checked(charArray.Length - 1);
            int index3 = 0;
            while (index3 <= num3)
            {
                if (Operators.CompareString(Conversions.ToString(charArray[index3]), " ", false) != 0)
                {
                    InputStr += Conversions.ToString(charArray[index3]);
                }
                else
                {
                    numArray[index2] = checked((byte)Math.Round(Conversion.Val(InputStr)));
                    checked { ++index2; }
                    InputStr = "";
                }
                checked { ++index3; }
            }
            return numArray;
        }

        private string ConvertToString(byte[] CipherData)
        {
            string str = "";
            int num = checked(CipherData.Length - 1);
            int index = 0;
            while (index <= num)
            {
                str = str + CipherData[index].ToString() + " ";
                checked { ++index; }
            }
            return str;
        }
    }
}
