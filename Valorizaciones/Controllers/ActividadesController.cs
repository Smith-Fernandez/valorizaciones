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
    public class ActividadesController : Controller
    {
        ActividadesAdmin adminActividades = new ActividadesAdmin();

        // GET: Actividades
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult js_actividades()
        {
            IEnumerable<ActividadesModel> lista = adminActividades.ConsultarAll();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}