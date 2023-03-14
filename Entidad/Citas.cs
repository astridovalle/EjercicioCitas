//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidad
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Citas
    {
        public int Id { get; set; }
        [Required]
        public System.DateTime Fecha { get; set; }
        public bool Aprobada { get; set; }
        public string MotivoRechazo { get; set; }
        public string Observaciones { get; set; }
        [DataType(DataType.Time)]
        public Nullable<System.TimeSpan> Hora { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int AutoId { get; set; }
        public System.DateTime CreatedAt { get; set; }
    
        public virtual Autos Autos { get; set; }
        public virtual Clientes Clientes { get; set; }
    }
}
