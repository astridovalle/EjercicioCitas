using Entidad;
using Entidad.DTO;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EjercicioCitas.Controllers
{
    public class CitasApiController : ApiController
    {

        public HttpResponseMessage Post([FromBody] Citas cita)
        {
            try
            {
                
                CitasBLL.EditCita(cita);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            
        }

        [HttpGet]
        public List<AutosDTO> GetAutosForCita(int IdCliente) 
        {
            try
            {
                return AutosBLL.GetAutosDTOByCliente(IdCliente);
            }
            catch (Exception)
            {
                throw;
            }
           
        }

    }
}
