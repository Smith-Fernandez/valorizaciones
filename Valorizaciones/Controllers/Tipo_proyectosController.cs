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
    public class Tipo_proyectosController : Controller
    {

        Tipo_proyectosAdmin adminTipo_proyectos = new Tipo_proyectosAdmin();
        // GET: Tipo_proyectos
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult js_tipo_proyectos()
        {
            IEnumerable<Tipo_proyectosModel> lista = adminTipo_proyectos.ConsultarAll();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}