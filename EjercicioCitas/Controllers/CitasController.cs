using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioCitas.Controllers
{
    public class CitasController : BaseController
    {
        // GET: Citas
        public ActionResult Index()
        {
            ViewBag.Rol = Session["Rol"];

            if (ViewBag.Rol == "Cliente")
            {
                var citas = CitasBLL.GetCitasByCliente(Convert.ToInt32(Session["UserId"]));
                return View(citas);
            }
            
            if (ViewBag.Rol == "Administrador")
            {
                var citas = CitasBLL.GetCitas();
                return View(citas);
            }
            else 
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Create()
        {

            ViewBag.UserId = Session["UserId"];
            var clientes = ClientesBLL.GetClientes();
            var autos = AutosBLL.GetAutosByCliente(clientes.First().Id);
            ViewData["ClienteId"] = new SelectList(clientes, "Id", "Nombre") ;
            ViewData["AutoId"] = new SelectList(autos, "Id", "Matricula");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Citas citas)
        {
            try
            {
                var crear = CitasBLL.CreateCita(citas);
                if (crear == "Ok")
                {
                    return RedirectToAction("Index");
                }
                else 
                {
                    ModelState.AddModelError("", crear);
                    ViewBag.UserId = Session["UserId"];
                    var clientes = ClientesBLL.GetClientes();
                    var autos = AutosBLL.GetAutosByCliente(clientes.First().Id);
                    ViewData["ClienteId"] = new SelectList(clientes, "Id", "Nombre");
                    ViewData["AutoId"] = new SelectList(autos, "Id", "Matricula");
                    return View(citas);
                }
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al agregar; " + ex.Message);
                return View(citas);
            }

        }


    }
}