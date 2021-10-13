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
    public class PartidasController : Controller
    {
        PartidasAdmin adminPartidas = new PartidasAdmin();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult js_partidas()
        {
            IEnumerable<Partida_unidadesModel> lista = adminPartidas.ConsultarAll();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult js_partidas_ByPartida(string partida_id)
        {
            IEnumerable<Partida_unidadesModel> lista = adminPartidas.ConsultarByPartida(partida_id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult js_partidas_buscador(string term)
        {
            IEnumerable<PartidasModel> lista = adminPartidas.ConsultarBuscador(term);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insert(PartidasModel objPartidas)
        {
            adminPartidas.Insert(objPartidas);
            return View("Index");
        }

        public ActionResult modificar(int id)
        {
            Partida_unidadesModel modelo = adminPartidas.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult Update(Partida_unidadesModel objPartida_unidades)
        {
            adminPartidas.Update(objPartida_unidades);
            return View("Index");
        }

        public ActionResult eliminar(int id)
        {
            Partida_unidadesModel modelo = adminPartidas.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult Delete_update(int partida_id)
        {
            adminPartidas.Delete_update(partida_id);
            return View("Index");
        }        

        public ActionResult vistaPrueba()
        {
            return View();
        }

    }
}