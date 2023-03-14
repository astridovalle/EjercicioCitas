using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioCitas.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            object obj = Session["UserId"];
            if (obj != null)
            {
                ViewBag.CitasAceptadas = CitasBLL.GetCitasByStatus(true);
                ViewBag.CitasRechazadas = CitasBLL.GetCitasByStatus(false);
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}