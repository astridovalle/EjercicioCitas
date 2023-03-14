using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioCitas.Controllers
{
    public class AdministradoresController : BaseController
    {
        // GET: Administradores
        public ActionResult Index()
        {
            ViewBag.Rol = Session["Rol"];
            if (ViewBag.Rol == null) 
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var admin = AdministradoresBLL.GetAdministradores();
                return View(admin);
            }
            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Administradores administrador)
        {
            try
            {
                administrador.RoleId = 1;

                AdministradoresBLL.CreateAdministradores(administrador);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al agregar; " + ex.Message);
                return View(administrador);
            }

        }

        public ActionResult Edit(int id)
        {
            var admin = AdministradoresBLL.GetAdministradoresById(id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult Edit(Administradores administrador)
        {

            try
            {
                AdministradoresBLL.EditAdministradores(administrador);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al editar; " + ex.Message);

                return View(administrador);
            }

        }

        public ActionResult Details(int id)
        {
            var admin = AdministradoresBLL.GetAdministradoresById(id);
            return View(admin);
        }

        [HttpPost]
        public void Delete(int Id)
        {
            try
            {
                AdministradoresBLL.DeleteAdministradores(Id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al eliminar; " + ex.Message);
            }
        }

    }
}