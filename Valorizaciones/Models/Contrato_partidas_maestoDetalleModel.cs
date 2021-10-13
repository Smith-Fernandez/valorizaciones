using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class Contrato_partidas_maestoDetalleModel
    {
        public int contrato_id { get; set; }
        public string presupuesto_notas { get; set; }
        public List<Partida> partidas { get; set; }
    }

    public class Partida
    {
        public int contrato_partida_id { get; set; }
        public int aprobancion_contratista { get; set; }
    }
}