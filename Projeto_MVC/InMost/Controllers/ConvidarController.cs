using InMost.BLL;
using InMost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InMost.Controllers
{
    public class ConvidarController : Controller
    {
        // GET: Convidar
        public ActionResult Convidar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnviarMail(ConvidarModel destinatario)
        {
            ConvidarBLL BLL = new ConvidarBLL();


            int Validacao = BLL.EnviarMail(destinatario.email);
            ViewBag.Validacao = Validacao;          

            return View("Convidar",new ConvidarModel()); 
        }


       
    }
}