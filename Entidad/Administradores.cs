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

    public partial class Administradores
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellidos { get; set; }
        [MaxLength(10)]
        public string Celular { get; set; }
        [Required]
        [MaxLength(100)]
        public string Correo { get; set; }
        public System.DateTime CreatedAt { get; set; }
        [Required]
        public string Contrasena { get; set; }
        public Nullable<int> RoleId { get; set; }
    
        public virtual Roles Roles { get; set; }
    }
}