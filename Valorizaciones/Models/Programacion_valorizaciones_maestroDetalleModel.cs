using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class Programacion_valorizaciones_maestroDetalleModel
    {
        public int id { get; set; }
        public int contrato_id { get; set; }
        public int programacion_id { get; set; }
        public int ejecucion { get; set; }
        public decimal amortizacion { get; set; }
        public string fecha { get; set; }
        public int estado { get; set; }
        
        public int tipo_usuario { get; set; }
        public int contratista_id { get; set; }
        public int supervisor_id { get; set; }
        public int valorizacion_supervisor_id { get; set; }
            
        public List<Valorizacion> valorizaciones { get; set; }
    }

    public class Valorizacion
    {        
        public int id { get; set; }
        public int programacion_ejecucion_id { get; set; }
        public int contrato_partida_id { get; set; }
        public decimal cantidad { get; set; }
        public int aprobacion_contratista { get; set; }
    }
}