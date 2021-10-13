using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class ContratoProgramacionModel
    {
        public int id { get; set; }
        public string fecha { get; set; }
        public decimal porcentaje { get; set; }
        public decimal presupuesto_referencial { get; set; }
        public decimal presupuesto_contratado { get; set; }
    }
}