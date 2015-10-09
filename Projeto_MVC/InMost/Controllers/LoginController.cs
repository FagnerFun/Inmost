using InMost.BLL;
using InMost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InMost.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Logar(LoginModel login)
        {
            LoginBLL BLL = new LoginBLL();
            if(BLL.VerificaLogin(login))
            {
                ViewBag.Validacao = true;
                Session["USR"] = login;
                return RedirectToAction("Index", "Home");
            }


            ViewBag.Validacao = false;
            return View("login",login);
        }

    }
}