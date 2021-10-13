using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Valorizaciones.Models
{
    public class ActividadesModel
    {
        public int id { get; set; }
        public string actividad { get; set; }
        public string abreviatura { get; set; }
        public int eliminado { get; set; }
    }
}