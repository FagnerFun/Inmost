using InMost.DAO;
using InMost.Entity;
using InMost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using InMost.Component;

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


        private LoginEntity LoginModeltoLoginEntity(LoginModel model)
        {
            LoginEntity entity = new LoginEntity();
            entity.Email = model.User;
            entity.Senha = Crypto.MD5(model.Password);
            return entity;
        }

    }
}
