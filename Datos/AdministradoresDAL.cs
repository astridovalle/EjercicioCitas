using Entidad;
using Entidad.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AdministradoresDAL
    {

        public List<Administradores> GetAdministradores() 
        {
            using (var context = new EjercicioCitasContext())
            {
                return context.Administradores.ToList();
            }
        }

        public Administradores GetAdministradoresById(int id) {
            using (var context = new EjercicioCitasContext())
            {
                return context.Administradores.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public void CreateAdministradores(Administradores administrador) 
        {
            try
            {
                using (var context = new EjercicioCitasContext())
                {
                    administrador.Contrasena = AESCryptography.Encrypt(administrador.Contrasena);
                    administrador.CreatedAt = DateTime.Now;
                    context.Administradores.Add(administrador);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void EditAdministradores(Administradores administrador)
        {
            try
            {
                using (var context = new EjercicioCitasContext())
                {
                    var admin = context.Administradores.Where(x => x.Id == administrador.Id).FirstOrDefault();
                    admin.Nombres = administrador.Nombres;
                    admin.Apellidos = administrador.Apellidos;
                    admin.Celular = administrador.Celular;
                    admin.Correo = administrador.Correo;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteAdministradores(int id) 
        {
            try
            {
                using (var context = new EjercicioCitasContext())
                {
                    var Admin = context.Administradores.Where(x => x.Id == id).FirstOrDefault();
                    context.Administradores.Remove(Admin);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Administradores LoginAdministrador(string contrasena, string correo) 
        {
            using (var context = new EjercicioCitasContext())
            {
                var Admin = context.Administradores.Where(x => x.Correo == correo && x.Contrasena.Contains(contrasena)).Include(x => x.Roles).FirstOrDefault();
                return Admin;
            }
        }

    }
}
