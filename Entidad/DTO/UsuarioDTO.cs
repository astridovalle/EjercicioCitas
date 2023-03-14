using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.DTO
{
    public class UsuarioDTO
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public bool Administrador { get; set; }
    }
}
