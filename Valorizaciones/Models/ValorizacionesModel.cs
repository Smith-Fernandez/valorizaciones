using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class ValorizacionesModel
    {
        public int id { get; set; }
        public int programacion_ejecucion_id { get; set; }
        public int contrato_partida_id { get; set; }
        public decimal cantidad { get; set; }
        public int aprobacion_contratista { get; set; }
    }
}