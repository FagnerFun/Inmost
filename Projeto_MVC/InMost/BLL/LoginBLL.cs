using InMost.DAO;
using InMost.Entity;
using InMost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMost.BLL
{
    class LoginBLL
    {
        #region 
        private LoginDAO _DAO = null;
        public LoginDAO LoginDAO
        {
            get
            {
                if (_DAO == null)
                    _DAO = new LoginDAO();
                return _DAO;
            }
        }

        #endregion

        public bool VerificaLogin(LoginModel model)
        {
            if(!string.IsNullOrEmpty(model.User) || !string.IsNullOrEmpty(model.Password))
                if(model.User.Length > 0 && model.User.Length <= 50 && model.Password.Length > 0 && model.Password.Length < 20)
                {
                    _DAO.EfetuaLogin(LoginModeltoLoginEntity(model));
                     
                } 

            return false;
        }

        public void MD5()
        {
            //Implementar MD5
        }


        public LoginEntity LoginModeltoLoginEntity(LoginModel model)
        {
            LoginEntity entity = new LoginEntity();
            entity.User = model.User;
            entity.Password = model.Password;
            return entity;
        }

    }
}
