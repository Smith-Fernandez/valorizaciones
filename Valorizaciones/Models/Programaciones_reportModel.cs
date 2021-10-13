using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class Programaciones_reportModel
    {
        public int contratista_id { get; set; }
        public int supervisor_id { get; set; }
        public decimal presupuesto_contratado { get; set; }
        public int contrato_id { get; set; }
        public int programacion_id { get; set; }
        public string fecha { get; set; }
        public decimal porcentaje { get; set; }
        public int programacion_ejecucion_id { get; set; }
        public decimal total_real { get; set; }
    }
}