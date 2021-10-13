using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class Cabecera_resumenModel
    {
        public string Usuario { get; set; }
        public string Proyecto { get; set; }
        public string Abreviatura { get; set; }
        public decimal presupuesto_referencial { get; set; }
        public decimal presupuesto_contratado { get; set; }
        public int Tipo_usuario_id { get; set; }
    }
}