using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class Contrato_proyectosModel
    {
        public int proyecto_id { get; set; }
        public string proyecto { get; set; }
        public int contrato_id { get; set; }
        public string ruc { get; set; }
        public string razon_social { get; set; }
        public string numero { get; set; }
        public string fecha { get; set; }
        public decimal plazo { get; set; }
        public decimal presupuesto_referencial { get; set; }
        public decimal presupuesto_contratado { get; set; }                      
        public decimal adelanto_directo { get; set; }
        public decimal gastos_generales { get; set; }
        public decimal gastos_otros { get; set; }
        public decimal utilidad { get; set; }
        public string fecha_inicio_obra { get; set; }
        public string fecha_inicio_obra_max { get; set; }
        public string fecha_entrega_terreno { get; set; }
        public int estado { get; set; }
        public string value { get; set; }
        public decimal porcentaje_ganador { get; set; }
    }
}