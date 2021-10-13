using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class ValorizacionesSumaModel
    {
        public int id { get; set; }
        public int programacion_id { get; set; }
        public string fecha { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal total { get; set; }
    }
}