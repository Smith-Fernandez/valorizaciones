using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Valorizaciones.Models;
using Valorizaciones.Datos;

namespace Valorizaciones.Controllers
{
    public class HomeController : Controller
    {
        ContratosAdmin adminContratos = new ContratosAdmin();

        // GET: Home  
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult js_contratos()
        {            
            IEnumerable<Contrato_proyectosModel> lista = adminContratos.Contrato_proyectos_All();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}