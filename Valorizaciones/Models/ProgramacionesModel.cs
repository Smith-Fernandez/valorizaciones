using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class ProgramacionesModel
    {
        public int id { get; set; }
        public int contrato_id { get; set; }
        public string fecha { get; set; }
        public decimal porcentaje { get; set; }
    }
}