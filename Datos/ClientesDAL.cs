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
    public class ClientesDAL
    {
        public List<Clientes> GetClientes() 
        {
            using (var context = new EjercicioCitasContext()) {
                return context.Clientes.ToList();
            }
        }

        public Clientes GetClientesById(int Id) 
        {
            using (var context = new EjercicioCitasContext())
            {
                return context.Clientes.Where(x => x.Id == Id).FirstOrDefault();
            }
        }

        public Clientes GetClientesByCorreo(string correo)
        {
            using (var context = new EjercicioCitasContext())
            {
                return context.Clientes.Where(x => x.Correo == correo).FirstOrDefault();
            }
        }
        
        public  void CreateCliente(Clientes cliente) 
        {
            try
            {
                using (var context = new EjercicioCitasContext())
                {
                    cliente.RoleId = 2;
                    cliente.Contrasena = AESCryptography.Encrypt(cliente.Contrasena);
                    cliente.CreatedAt = DateTime.Now;
                    context.Clientes.Add(cliente);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void EditClientes(Clientes cliente)
        {
            try
            {
                using (var context = new EjercicioCitasContext())
                {
                    var Cli = context.Clientes.Where(x => x.Id == cliente.Id).FirstOrDefault();
                    Cli.Correo = cliente.Correo;
                    Cli.Celular = cliente.Celular;
                    Cli.Apellidos = cliente.Apellidos;
                    Cli.Nombre = cliente.Nombre;

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCliente(int id) 
        {
            try
            {
                using (var context = new EjercicioCitasContext())
                {
                    var Cli = context.Clientes.Where(x => x.Id == id).FirstOrDefault();
                    context.Clientes.Remove(Cli);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Clientes LoginClienetes(string contrasena, string correo) 
        {
            using (var context = new EjercicioCitasContext())
            {
                var Cli = context.Clientes.Where(x => x.Correo == correo && x.Contrasena.Contains(contrasena)).Include(x => x.Roles).FirstOrDefault();
                return Cli;
            }
        }

    }
}
