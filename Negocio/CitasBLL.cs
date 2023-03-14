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
    public class CitasBLL
    {
        private static CitasDAL obj = new CitasDAL();

        public static List<CitasDTO> GetCitas() 
        {
            return obj.GetCitas();
        }

        public static List<CitasDTO> GetCitasByStatus(bool aprobada)
        {
            return obj.GetCitasByStatus(aprobada);
        }

        public static List<CitasDTO> GetCitasByCliente(int id)
        {
            return obj.GetCitasByCliente(id);
        }

        public static string CreateCita(Citas cita)
        {
            return obj.CreateCita(cita);
        }

        public static void EditCita(Citas cita)
        {
            obj.EditCita(cita);
        }

        public static bool CompareCitas(TimeSpan hora, DateTime fecha) 
        {
            return obj.CompareCitas(hora, fecha);
        }

    }
}
