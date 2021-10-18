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
    public class ContratosController : Controller
    {
        ContratosAdmin adminContratos = new ContratosAdmin();

        public ActionResult Index()
        {            
            return View();
        }

        public JsonResult js_contratos()
        {
            IEnumerable<Contrato_proyectosModel> lista = adminContratos.Contrato_proyectos_All();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Contratos_ByUsuario(int id)
        {
            IEnumerable<Contrato_proyectosModel> lista = adminContratos.Contratos_ByUsuario(id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult js_contratos_buscador(string term)
        {
            IEnumerable<Contrato_proyectosModel> lista = adminContratos.ConsultarBuscador(term);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult js_cabecera_resumen(int id)
        {
            IEnumerable<Cabecera_resumenModel> lista = adminContratos.Cabecera_resumen(id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult js_contrato_ById(int id)
        {
            ContratosModel objContrato = adminContratos.Contrato_Byid(id);
            return Json(objContrato, JsonRequestBehavior.AllowGet);
        }

        public ActionResult adjuntar_partida()
        {
            return View();
        }

        public ActionResult nuevo()
        {
            return View();
        }

        public ActionResult insert(ContratosModel objContrato)
        {
            adminContratos.Insert(objContrato);
            return View("Index");
        }

        public ActionResult modificar(int id)
        {
            ContratosModel modelo = adminContratos.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult Update(ContratosModel objContratos)
        {
            adminContratos.Update(objContratos);
            return View("Index");
        }

        public ActionResult perfil(int id)
        {
            ContratosModel modelo = adminContratos.Contrato_Byid(id);
            return View(modelo);
        }

        //public ActionResult Print()
        //{
        //    return new Rotativa.ActionAsPdf("Index");
        //}
        public ActionResult eliminar(int id)
        {
             ContratosModel modelo = adminContratos.Contrato_Byid(id);
            //return View(modelo);
            return View(modelo);
        }
        public ActionResult Delete_update(int id)
        {
            adminContratos.Delete_update(id);
            return View("Index");
        }

    }
}