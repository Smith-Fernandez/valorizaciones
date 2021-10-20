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
    public class ProyectosController : Controller
    {        
        ProyectosAdmin admin = new ProyectosAdmin();
        VariablesAdmin variables = new VariablesAdmin();

        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult js_proyectos()
        {
            IEnumerable<ProyectosModel> lista = admin.ConsultarAll();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult js_proyecto_ById(int id)
        {
            ProyectosModel objProyecto = admin.Proyecto_Byid(id);
            return Json(objProyecto, JsonRequestBehavior.AllowGet);
        }

        public ActionResult indexo()
        {
            return View();
        }        

        public ActionResult Guardar()
        {
            return View();
        }

        public ActionResult Nuevo(ProyectosModel modelo)
        {
            //cambio 19-10-2021
            admin.Guardar(modelo);
            IEnumerable<ProyectosModel> lista = admin.Consultar();
            return View("Index", lista);
        }

        public ActionResult Edit(int id)
        {
            ProyectosModel modelo = admin.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult Update(ProyectosModel modelo)
        {
            admin.Update(modelo);
            IEnumerable<ProyectosModel> lista = admin.Consultar();
            return View("Index", lista);
        }

        public ActionResult Delete(int id)
        {
            /*admin.Delete(id);
            IEnumerable<ProyectosModel> lista = admin.Consultar();
            return View("Index", lista);*/
            ProyectosModel modelo = admin.ConsultarItem(id);
            return View(modelo);
        }
        public ActionResult Delete_update(int id)
        {
            admin.Delete_update(id);
            return View("Index");
        }

        [HttpGet]
        public JsonResult js_proyectos_buscador(string term)
        {
            IEnumerable<ProyectosModel> lista = admin.ConsultarBuscador(term);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

    }
}