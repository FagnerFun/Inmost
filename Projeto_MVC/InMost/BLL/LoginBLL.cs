using InMost.DAO;
using InMost.Entity;
using InMost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;

namespace InMost.BLL
{
    class LoginBLL
    {
        

        public bool VerificaLogin(LoginModel model)
        {
            LoginDAO DAO = new LoginDAO();

            if(!string.IsNullOrEmpty(model.User) && !string.IsNullOrEmpty(model.Password))
                if(model.User.Length > 0 && model.User.Length <= 200 && model.Password.Length >= 4 && model.Password.Length < 20)
                {
                    DataTable data = DAO.EfetuaLogin(LoginModeltoLoginEntity(model));

                    return data.Rows.Count > 0; 

                                         
                } 

            return false;
        }

        public string MD5(string texto)
        {
            MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes("BetaInmost"));
            des.Mode = CipherMode.ECB;

            ICryptoTransform crypt = des.CreateEncryptor();

            byte[] buff = ASCIIEncoding.ASCII.GetBytes(texto);
            return Convert.ToBase64String(crypt.TransformFinalBlock(buff, 0, buff.Length));
        }


        private LoginEntity LoginModeltoLoginEntity(LoginModel model)
        {
            LoginEntity entity = new LoginEntity();
            entity.Email = model.User;
            entity.Senha = MD5(model.Password);
            return entity;
        }

    }
}
