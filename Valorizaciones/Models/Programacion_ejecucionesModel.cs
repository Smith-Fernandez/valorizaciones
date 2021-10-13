using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class Programacion_ejecucionesModel
    {
        public int id { get; set; }
        public int programacion_id { get; set; }
        public int ejecucion { get; set; }
        public decimal amortizacion { get; set; }
        public string fecha { get; set; }
        public int estado { get; set; }

        public int contratista_id { get; set; }
        public int supervisor_id { get; set; }
        public int valorizacion_supervisor_id { get; set; }            
    }
}