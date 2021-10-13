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
    public class Tipo_usuariosController : Controller
    {
        Tipo_usuariosAdmin adminTipo_proyectos = new Tipo_usuariosAdmin();
        // GET: Tipo_usuarios
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult js_tipo_usuarios()
        {
            IEnumerable<Tipo_usuariosModel> lista = adminTipo_proyectos.ConsultarAll();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
    }
}