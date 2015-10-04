using InMost.BLL;
using InMost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InMost.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            HomeModel model = new HomeModel();
            if (Session["USR"] == null)
                return RedirectToAction("Login","Login");

            model.Email = ((LoginModel)Session["USR"]).User;

            HomeBLL BLL = new HomeBLL();
            model = BLL.CarregaUsuario(model);

            
            return View(model);
        }

       

        public void LoadIndex(HomeModel model)
        {

            HomeBLL BLL = new HomeBLL();
            BLL.CarregaUsuario(model);


        }


    }
}