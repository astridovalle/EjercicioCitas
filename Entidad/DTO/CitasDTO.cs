using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.DTO
{
    public class CitasDTO
    {
            public int Id { get; set; }
            public string Aprobada { get; set; }
            public string Cliente { get; set; }
            public int ClienteId { get; set; }
            public string Auto { get; set; }
            public int AutoId { get; set; }
            public DateTime FechaEntrega { get; set; }
            public DateTime Fecha { get; set; }
            public TimeSpan Hora { get; set; }
            public string MotivoRechazo { get; set; }
            public string Observaciones { get; set; }

    }
}
