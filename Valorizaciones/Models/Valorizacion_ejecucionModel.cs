using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class Valorizacion_ejecucionModel
    {        
        public int programacion_id { get; set; }
        public int supervisor_id { get; set; }
        public decimal precio { get; set; }
        public decimal cantidad { get; set; }
        public int partida_id { get; set; }
        public int contrato_partida_id { get; set; }
        public int programacion_ejecucion_id { get; set; }
    }
}