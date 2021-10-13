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
    public class ProgramacionesController : Controller
    {
        ProgramacionesAdmin adminProgramaciones = new ProgramacionesAdmin();
        VariablesAdmin variables = new VariablesAdmin();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult js_programaciones_ByContrato(int id)
        {
            IEnumerable<ProgramacionesModel> lista = adminProgramaciones.ConsultarAllByContrato(id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult report_programaciones(int id)
        {
            IEnumerable<Programaciones_reportModel> lista = adminProgramaciones.report_programaciones(id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        
        public JsonResult MontoContatoConProgramacion(int id)
        {
            IEnumerable<ContratoProgramacionModel> lista = adminProgramaciones.MontoContatoConProgramacion(id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult js_programaciones_ById(int id)
        {
            ProgramacionesModel objProgramacion = adminProgramaciones.ConsultarItem(id);
            return Json(objProgramacion, JsonRequestBehavior.AllowGet);
        }

        public JsonResult filasProgramacionesEjecucion(int id)
        {
            ProgramacionesModel objProgramacion = adminProgramaciones.filasProgramacionesEjecucion(id);
            return Json(objProgramacion, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Nuevo(string contrato_id)
        {
            ViewData["vw_contrato_id"] = contrato_id;
            return View();
        }

        public ActionResult Insert(ProgramacionesModel objProgramacion)
        {
            adminProgramaciones.Insert(objProgramacion);
            return RedirectToAction("Index", new { id = variables.Param_URL() + objProgramacion.contrato_id });
            //return View("Index");
        }

        public ActionResult Modificar(int id)
        {
            ViewData["vw_contrato_id"] = id;
            ProgramacionesModel modelo = adminProgramaciones.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult Update(ProgramacionesModel objProgramacion)
        {
            adminProgramaciones.Update(objProgramacion);
            return RedirectToAction("Index", new { id = variables.Param_URL() + objProgramacion.contrato_id });
        }

        public ActionResult Eliminar(int id)
        {
            ProgramacionesModel modelo = adminProgramaciones.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult Delete(ProgramacionesModel objProgramacion)
        {
            adminProgramaciones.Delete(objProgramacion.id);
            return RedirectToAction("Index", new { id = variables.Param_URL() + objProgramacion.contrato_id });
        }

    }
}