using InMost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InMost.Controllers
{
    public class EditarPerfilController : Controller
    {
        // GET: EditarPerfil
        public ActionResult EditarPerfil()
        {
            return View();
        }


        public ActionResult SalvarEditarPerfil(EditarPerfilModel model)
        {




            return View(model);
        }
    }
}