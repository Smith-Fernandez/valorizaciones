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
    public class PaquetesController : Controller
    {
        PaquetesAdmin adminPaquetes = new PaquetesAdmin();

        // GET: Paquetes
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult js_paquetes()
        {
            IEnumerable<PaquetesModel> lista = adminPaquetes.ConsultarAll();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}