using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class Usuario_tipoModel
    {        
        public int usuario_id { get; set; }
        public string usuario { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public string numero_documento { get; set; }
        public string tipo_usuario { get; set; }
        public string value { get; set; }
        public int tipo_usuario_id { get; set; }
    }
}