using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class ValidacionSinFormatoModel
    {
        public string codigo { get; set; }
        public string partida { get; set; }
        public int partida_id { get; set; }
        public int programacion_ejecucion_id { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }

    }
}