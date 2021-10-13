using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Valorizaciones.Models;
using Valorizaciones.Datos;
using System.Data.SqlClient;

namespace Valorizaciones.Controllers
{
    public class UnidadesController : Controller
    {
        UnidadesAdmin adminUnidades = new UnidadesAdmin();
        
        // GET: Unidades
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult js_unidades()
        {
            IEnumerable<UnidadesModel> lista = adminUnidades.ConsultarAll();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}