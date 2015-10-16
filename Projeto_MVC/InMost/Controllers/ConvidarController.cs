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
        public string EnviarMail(ConvidarModel destinatario)
        {
            ConvidarBLL bll = new ConvidarBLL();
            
            return bll.EnviarMail(destinatario.email); 
        }
    }
}