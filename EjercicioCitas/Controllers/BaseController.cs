using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioCitas.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            object obj = Session["UserId"];
            if (obj != null)
            {
                ViewBag.UserId = Session["UserId"];
                ViewBag.Usuario = Session["UserName"];
                ViewBag.Rol = Session["Rol"];
            }
        }
    }
}