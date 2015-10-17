using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace InMost.Component
{
    public class Crypto
    {
        public static string MD5(string texto)
        {
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes("BetaInmost"));
            des.Mode = CipherMode.ECB;

            ICryptoTransform crypt = des.CreateEncryptor();

            byte[] buff = ASCIIEncoding.ASCII.GetBytes(texto);
            return Convert.ToBase64String(crypt.TransformFinalBlock(buff, 0, buff.Length));
        }
    }
}
