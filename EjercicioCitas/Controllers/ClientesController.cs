using Datos;
using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioCitas.Controllers
{
    public class ClientesController : BaseController
    {
        // GET: Clientes
        public ActionResult Index()
        {
            ViewBag.Rol = Session["Rol"];
            ViewBag.UserId = Session["UserId"];

            if (ViewBag.Rol == "Cliente")
            {
                var Cli = ClientesBLL.GetClientesById(Convert.ToInt32(ViewBag.UserId));
                List<Clientes> ClienteView = new List<Clientes>();
                ClienteView.Add(Cli);

                return View(ClienteView);
            }
            if (ViewBag.Rol == "Administrador")
            {
                var Cli = ClientesBLL.GetClientes();

                return View(Cli);
            }
            else {
                return RedirectToAction("Login", "Account");
            }
                
        }

        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Clientes cliente)
        {
            try
            {
                ClientesBLL.CreateCliente(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al agregar; " + ex.Message);
                return View(cliente);
            }
          
        }

        public ActionResult Edit(int id)
        {
            var Cli = ClientesBLL.GetClientesById(id);
            return View(Cli);
        }

        [HttpPost]
        public ActionResult Edit(Clientes cliente) 
        {

            try
            {
                ClientesBLL.EditClientes(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al editar; " + ex.Message);

                return View(cliente);
            }
           
        }

        public ActionResult Details(int id) 
        {
            var Cli = ClientesBLL.GetClientesById(id);
            return View(Cli);
        }

        [HttpPost]
        public void Delete(int Id) 
        {
            try
            {
                ClientesBLL.DeleteClientes(Id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrio un error al eliminar; " + ex.Message);
            }
        }

    }
}