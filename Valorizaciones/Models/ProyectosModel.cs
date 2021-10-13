using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class ProyectosModel
    {        
        public int id { get; set; }
        public string cui { get; set; }
        public string proyecto { get; set; }
        public string abreviatura { get; set; }    
        public int tipo_proyecto_id { get; set; }
        public int paquete_id { get; set; }
        public int actividad_id { get; set; }
        public string expediente_tecnico { get; set; }
        public decimal total_obra { get; set; }
        public decimal total_supervision { get; set; }
        public decimal total_interferencia { get; set; }
        public decimal total_gestion_proyecto { get; set; }
        public string ubigeo { get; set; }
        public string fecha_convocatoria { get; set; }
        public string fecha_estimada_buena_pro { get; set; }
        public string fecha_estimada_consentimiento { get; set; }
        public string fecha_estimada_contrato { get; set; }
        public string fecha_estimada_inicio { get; set; }
        public string fecha_entrega_terreno { get; set; }
        public int tiempo_ejecucion { get; set; }
        public int estado_registro { get; set; }

        public string value { get; set; }        
    }
}