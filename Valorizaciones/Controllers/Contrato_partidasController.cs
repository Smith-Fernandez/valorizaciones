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
    public class Contrato_partidasController : Controller
    {
        Contrato_partidasAdmin adminContrato_partidas = new Contrato_partidasAdmin();
        VariablesAdmin variables = new VariablesAdmin();
        ContratosAdmin adminContratos = new ContratosAdmin();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2(int id)
        {
            ViewBag.param_url = id;
            IEnumerable<Contrato_partidasModel> lista = adminContrato_partidas.ConsultarAllByContrato(id);
            return View(lista);
        }

        public ActionResult Print(int contrato_id)
        {
            return new Rotativa.ActionAsPdf("Index2", new { id = contrato_id });
        }

        public JsonResult js_contrato_partidas()
        {
            IEnumerable<Contrato_partidasModel> lista = adminContrato_partidas.ConsultarAll();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult js_contrato_partidas_ByContrato(int id)
        {
            IEnumerable<Contrato_partidasModel> lista = adminContrato_partidas.ConsultarAllByContrato((id));
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Nuevo(string contrato_id)
        {
            ViewData["vw_contrato_id"] = contrato_id;

            return View();
        }

        public ActionResult Insert(Contrato_partidasModel objContrato_partidas)
        {
            adminContrato_partidas.Insert(objContrato_partidas);
            return RedirectToAction("Index", new { id = variables.Param_URL() + objContrato_partidas.contrato_id });
            //return View("Index");
        }

        public ActionResult Modificar(int id)
        {
            Contrato_partidasModel modelo = adminContrato_partidas.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult Update(Contrato_partidasModel objContrato_partidas)
        {
            adminContrato_partidas.Update(objContrato_partidas);
            return RedirectToAction("Index", new { id = variables.Param_URL() + objContrato_partidas.contrato_id });
        }

        public ActionResult Eliminar(int id)
        {
            Contrato_partidasModel modelo = adminContrato_partidas.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult Delete(Contrato_partidasModel objContrato_partidas)
        {
            adminContrato_partidas.Delete(objContrato_partidas.id);
            return RedirectToAction("Index", new { id = variables.Param_URL() + objContrato_partidas.contrato_id });
        }

        public ActionResult Perfil(int id)
        {
            Contrato_partidasModel modelo = adminContrato_partidas.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult update_presupuesto(Contrato_partidas_maestoDetalleModel model)
        {
            ContratosModel objContrato = new ContratosModel();
            objContrato.id = model.contrato_id;
            objContrato.presupuesto_notas = model.presupuesto_notas;
            adminContratos.update_datos_presupuesto(objContrato);

            foreach (var oc in model.partidas)
            {
                Contrato_partidasModel objContratoPartidas = new Contrato_partidasModel();
                objContratoPartidas.id = oc.contrato_partida_id;
                objContratoPartidas.aprobancion_contratista = oc.aprobancion_contratista;
                adminContrato_partidas.updatePartida_aprobacion(objContratoPartidas);
            }

            return RedirectToAction("Index", new { id = variables.Param_URL() + model.contrato_id });
        }
    }
}