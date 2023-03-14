using Datos;
using Entidad;
using Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AutosBLL
    {
        private static AutosDAL obj = new AutosDAL();

        public static List<Autos> GetAutosByCliente(int IdCliente) 
        {
            return obj.GetAutosByCliente(IdCliente);
        }

        public static Autos GetAutoById(int id) 
        {
            return obj.GetAutoById(id);
        }

        public static List<AutosDTO> GetAutosDTOByCliente(int id)
        {
            return obj.GetAutosDTOByCliente(id);
        }

        
        public static  void CreateAuto(Autos auto) 
        {
            obj.CreateAuto(auto);
        }

        public static void EditAutos(Autos auto) 
        {
            obj.EditAutos(auto);
        }

        public static void DeleteAuto(int id) 
        {
            obj.DeleteAuto(id);
        }

    }
}
