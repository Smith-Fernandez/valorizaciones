using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class Partida_unidadesModel
    {
        public int partida_id { get; set; }
        public string partida { get; set; }
        public string value { get; set; }
        public int unidad_id { get; set; }
        public string unidad { get; set; }
        public int eliminado { get; set; }
    }
}