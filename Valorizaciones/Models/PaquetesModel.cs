using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class PaquetesModel
    {        
        public int id { get; set; }
        public string paquete { get; set; }
        public string abreviatura { get; set; }
        public int eliminado { get; set; }
    }
}