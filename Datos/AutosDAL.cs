using Entidad;
using Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AutosDAL
    {

        public List<Autos> GetAutosByCliente(int idCliente)
        {
            using (var context = new EjercicioCitasContext())
            {
                return context.Autos.Where(x => x.ClienteId == idCliente).Include(x => x.Clientes).ToList();
            }
        }

        public Autos GetAutoById(int id) 
        {
            using (var context = new EjercicioCitasContext())
            {
                return context.Autos.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public List<AutosDTO> GetAutosDTOByCliente(int idCliente)
        {
            using (var context = new EjercicioCitasContext())
            {
                return context.Autos.Where(x => x.ClienteId == idCliente).Select(x => new AutosDTO { 
                Id = x.Id,
                Matricula = x.Matricula
                }).ToList();
            }
        }

        public void CreateAuto(Autos auto)
        {
            try
            {
                using (var context = new EjercicioCitasContext())
                {
                    context.Autos.Add(auto);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void EditAutos(Autos auto)
        {
            try
            {
                using (var context = new EjercicioCitasContext())
                {
                    var a = context.Autos.Where(x => x.Id == auto.Id).FirstOrDefault();
                    a.Año = auto.Año;
                    a.Color = auto.Color;
                    a.Matricula = auto.Matricula;
                    a.Modelo = auto.Modelo;
                    
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteAuto(int id)
        {
            try
            {
                using (var context = new EjercicioCitasContext())
                {
                    var auto = context.Autos.Where(x => x.Id == id).FirstOrDefault();
                    context.Autos.Remove(auto);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
