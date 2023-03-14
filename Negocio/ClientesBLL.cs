using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public  class ClientesBLL
    {
        private static ClientesDAL obj = new ClientesDAL();

        public static List<Clientes> GetClientes()
        {
            return obj.GetClientes();
        }

        public static void CreateCliente(Clientes cliente) 
        {
            obj.CreateCliente(cliente);
        }

        public static Clientes GetClientesById(int id) 
        {
           return obj.GetClientesById(id);
        }

        public static Clientes GetClientesByCorreo(string correo)
        {
            return obj.GetClientesByCorreo(correo);
        }

        public static void EditClientes(Clientes cliente) 
        {
            obj.EditClientes(cliente);
        }

        public static void DeleteClientes(int id)
        {
            obj.DeleteCliente(id);
        }

        public static Clientes LoginClienetes(string contrasena, string correo) 
        {
            return obj.LoginClienetes(contrasena, correo);
        }

    }
}
