using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioCitas.Controllers
{
    public class AutosController : BaseController
    {
        // GET: Autos
        public ActionResult Index(int Id)
        {
            var Cli = ClientesBLL.GetClientesById(Id);
            ViewBag.Cliente = Cli.Nombre + " " + Cli.Apellidos;
            ViewBag.IdCliente = Cli.Id;

            var autos = AutosBLL.GetAutosByCliente(Id);

            return View(autos);
        }

        public ActionResult Create(int Id)
        {
            ViewBag.IdCliente = Id;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Autos auto)
        {
            try
            {
                AutosBLL.CreateAuto(auto);
                return RedirectToAction("Index", new { Id = auto.ClienteId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al agregar; " + ex.Message);
                return RedirectToAction("Index", new { Id = auto.ClienteId });
            }

        }
        public ActionResult Edit(int id)
        {
            ViewBag.IdCliente = id;
            var auto = AutosBLL.GetAutoById(id);
            return View(auto);
        }

        [HttpPost]
        public ActionResult Edit(Autos auto)
        {
            try
            {
                AutosBLL.EditAutos(auto);
                return RedirectToAction("Index", new { Id = auto.ClienteId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al editar; " + ex.Message);
                return RedirectToAction("Index", new { Id = auto.ClienteId });
            }

        }

        public ActionResult Details(int id)
        {
            var auto = AutosBLL.GetAutoById(id);
            return View(auto);
        }

        [HttpPost]
        public void Delete(int Id)
        {
            try
            {
                AutosBLL.DeleteAuto(Id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al eliminar; " + ex.Message);
            }
        }
    }
}