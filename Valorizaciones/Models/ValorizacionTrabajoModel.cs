using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class ValorizacionTrabajoModel
    {        
        public string partida { get; set; }
        public string codigo { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal cantidad_valorizado { get; set; }
        public int partida_id { get; set; }
        public int contrato_partida_id { get; set; }
        public int valorizacion_id { get; set; }
        public int programacion_ejecucion_id { get; set; }
        public int aprobacion_contratista { get; set; }
        public int amortizacion { get; set; }
        public int contratista_id { get; set; }
        public int supervisor_id { get; set; }
        public int valorizacion_supervisor_id { get; set; }        

        public int adelanto_directo { get; set; }
        public int gastos_generales { get; set; }
        public int gastos_otros { get; set; }
        public int utilidad { get; set; }              
    }
}