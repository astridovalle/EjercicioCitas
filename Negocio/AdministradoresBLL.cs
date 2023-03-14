using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AdministradoresBLL
    {
        private static AdministradoresDAL obj = new AdministradoresDAL();

        public static List<Administradores> GetAdministradores()
        {
            return obj.GetAdministradores();
        }

        public static Administradores GetAdministradoresById(int id) 
        {
            return obj.GetAdministradoresById(id);
        }

        public static void CreateAdministradores(Administradores administrador)
        {
            obj.CreateAdministradores(administrador);
        }

        public static void EditAdministradores(Administradores administrador) 
        {
            obj.EditAdministradores(administrador);
        }

        public static void DeleteAdministradores(int id) 
        {
            obj.DeleteAdministradores(id);
        }

        public static Administradores LoginAdministrador(string contrasena, string correo)
        {
            return obj.LoginAdministrador(contrasena, correo);
        }

    }
}
