using Entidad;
using Entidad.DTO;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioCitas.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Register(Clientes user)
		{
			if (ModelState.IsValid)
			{
				var validate_user = ClientesBLL.GetClientesByCorreo(user.Correo);
					if (validate_user == null)
					{
						user.Contrasena = AESCryptography.Encrypt(user.Contrasena);
						ClientesBLL.CreateCliente(user);
					}
					else
					{
						ViewBag.Message = "Ya existe un usuario" + user.Correo;
						return View();
					}
				
				
			}
			return RedirectToAction("Login");
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(UsuarioDTO user)
		{
			var contra = AESCryptography.Encrypt(user.Contrasena);
			if (user.Administrador) {
				
				var userLogged = AdministradoresBLL.LoginAdministrador(contra, user.Correo);

				if (userLogged != null) {
					Session["UserId"] = userLogged.Id.ToString();
					Session["UserName"] = userLogged.Correo.ToString();
					Session["Rol"] = userLogged.Roles.Nnombre.ToString();
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Usuario o contraseña incorrectas.");
				}
			} 
			else 
			{
				var userLogged = ClientesBLL.LoginClienetes(contra, user.Correo);

				if (userLogged != null)
				{
					Session["UserId"] = userLogged.Id.ToString();
					Session["UserName"] = userLogged.Correo.ToString();
					Session["Rol"] = userLogged.Roles.Nnombre.ToString();
					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Usuario o contraseña incorrectas.");
				}
			}
				
			return View();
		}

		public ActionResult LoggedIn()
		{
			object obj = Session["UserId"];
			if (obj != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Login");
			}

		}

		public ActionResult LogOut() 
		{
			Session.RemoveAll();
			Session.Abandon();
			return RedirectToAction("Login");
		}

	}
}