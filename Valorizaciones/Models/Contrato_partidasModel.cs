using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class Contrato_partidasModel
    {
        public int id { get; set; }
        public int contrato_id { get; set; }
        public int partida_id { get; set; }
        public string partida { get; set; }
        public string codigo { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public int aprobancion_contratista { get; set; }
    }
}