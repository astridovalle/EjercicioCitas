using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad.DTO;
using System.Data.Entity;

namespace Datos
{
    public class CitasDAL
    {

        public List<CitasDTO> GetCitas()
        {
            using (var context = new EjercicioCitasContext())
            {
                return context.Citas.Select(cita => new CitasDTO
                {
                    Id = cita.Id,
                    Aprobada = cita.Aprobada ? "Aprobada" : "Rechazada",
                    Cliente = cita.Clientes.Nombre + " " + cita.Clientes.Apellidos,
                    ClienteId = cita.ClienteId,
                    Auto = cita.Autos.Matricula,
                    AutoId = cita.AutoId,
                    FechaEntrega = cita.FechaEntrega,
                    Hora = cita.Hora.Value,
                    MotivoRechazo = cita.MotivoRechazo,
                    Observaciones = cita.Observaciones,
                    Fecha = cita.Fecha

                }).ToList();
            }
        }

        public List<CitasDTO> GetCitasByCliente(int id)
        {
            using (var context = new EjercicioCitasContext())
            {
                return context.Citas.Where(x => x.ClienteId == id).Select(cita => new CitasDTO
                {
                    Id = cita.Id,
                    Aprobada = cita.Aprobada ? "Aprobada" : "Rechazada",
                    Cliente = cita.Clientes.Nombre + " " + cita.Clientes.Apellidos,
                    ClienteId = cita.ClienteId,
                    Auto = cita.Autos.Matricula,
                    AutoId = cita.AutoId,
                    FechaEntrega = cita.FechaEntrega,
                    Hora = cita.Hora.Value,
                    MotivoRechazo = cita.MotivoRechazo,
                    Observaciones = cita.Observaciones,
                    Fecha = cita.Fecha

                }).ToList();
            }
        }

        public List<CitasDTO> GetCitasByStatus(bool aprobada)
        {
            using (var context = new EjercicioCitasContext())
            {
                return context.Citas.Where(x => x.Aprobada == aprobada).Select(cita => new CitasDTO
                {
                    Id = cita.Id,
                    Aprobada = cita.Aprobada ? "Aprobada" : "Rechazada",
                    Cliente = cita.Clientes.Nombre + " " + cita.Clientes.Apellidos,
                    ClienteId = cita.ClienteId,
                    Auto = cita.Autos.Matricula,
                    AutoId = cita.AutoId,
                    FechaEntrega = cita.FechaEntrega,
                    Hora = cita.Hora.Value,
                    MotivoRechazo = cita.MotivoRechazo,
                    Observaciones = cita.Observaciones,
                    Fecha = cita.Fecha

                }).ToList();
            }
        }

        public string CreateCita(Citas citas)
        {
            try
            {
                using (var context = new EjercicioCitasContext())
                {
                    var disponible = CompareCitas(citas.Hora.Value, citas.Fecha);

                    if (disponible)
                    {
                        citas.CreatedAt = DateTime.Now;
                        citas.FechaEntrega = DateTime.Now;

                        context.Citas.Add(citas);
                        context.SaveChanges();
                        return "Ok";
                    }
                    else {
                        return  "Hay otra cita reserveda en un lapso de dos horas.";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void EditCita(Citas cita)
        {
            using (var context = new EjercicioCitasContext())
            {
                var cit = context.Citas.Where(x => x.Id == cita.Id).FirstOrDefault();

                cit.Aprobada = cita.Aprobada;
                cit.MotivoRechazo = cita.MotivoRechazo;
                cit.Observaciones = cita.Observaciones;
                cit.FechaEntrega = cita.Aprobada ? cita.FechaEntrega : DateTime.Now;

                context.SaveChanges();
                
            }
        }

        public bool CompareCitas(TimeSpan hora, DateTime fecha) {
            var horasAntes = hora - TimeSpan.FromHours(2);
            var horasDespues = hora + TimeSpan.FromHours(2);

            using (var context = new EjercicioCitasContext())
            {
                var citas = context.Citas.Where(x => DbFunctions.TruncateTime(x.Fecha) == fecha && (x.Hora.Value > horasAntes && x.Hora.Value <= horasDespues)).ToList();

                if (citas.Count > 0)
                    return false;
                else
                    return true;
            }

        }

    }
}

