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
    public class Contrato_usuariosController : Controller
    {
        Contrato_usuariosAdmin adminContrato_usuarios = new Contrato_usuariosAdmin();
        VariablesAdmin variables = new VariablesAdmin();

        // GET: Contrato_usuarios
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult js_contrato_usuarios()
        {
            IEnumerable<Contrato_usuariosModel> lista = adminContrato_usuarios.ConsultarAll();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult js_contrato_usuarios_ByContrato(int id)
        {
            IEnumerable<Contrato_usuariosModel> lista = adminContrato_usuarios.ConsultarAllByContrato((id));
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Nuevo(string contrato_id)
        {
            ViewData["vw_contrato_id"] = contrato_id;

            return View();
        }

        public ActionResult Insert(Contrato_usuariosModel objContrato_usuarios)
        {
            adminContrato_usuarios.Insert(objContrato_usuarios);
            return RedirectToAction("Index", new { id = variables.Param_URL() + objContrato_usuarios.contrato_id });
            //return View("Index");
        }

        public ActionResult Modificar(int id)
        {
            Contrato_usuariosModel modelo = adminContrato_usuarios.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult Update(Contrato_usuariosModel objContrato_usuarios)
        {
            adminContrato_usuarios.Update(objContrato_usuarios);
            return RedirectToAction("Index", new { id = variables.Param_URL() + objContrato_usuarios.contrato_id });
        }

        public ActionResult Eliminar(int id)
        {
            Contrato_usuariosModel modelo = adminContrato_usuarios.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult Delete(Contrato_usuariosModel objContrato_usuarios)
        {
            adminContrato_usuarios.Delete(objContrato_usuarios.contrato_usuario_id);
            return RedirectToAction("Index", new { id = variables.Param_URL() + objContrato_usuarios.contrato_id });
        }

        public ActionResult Perfil(int id)
        {
            Contrato_usuariosModel modelo = adminContrato_usuarios.ConsultarItem(id);
            return View(modelo);
        }
    }
}