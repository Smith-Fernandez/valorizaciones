using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Valorizaciones.Datos;
using Valorizaciones.Models;

namespace Valorizaciones.Controllers
{
    public class UsuariosController : Controller
    {
        UsuariosAdmin adminUsers = new UsuariosAdmin();
        Usuario_tipoAdmin adminUser_tipo = new Usuario_tipoAdmin();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult nuevo()
        {
            return View();
        }

        public ActionResult modificar(int id)
        {
            Usuario_tipoModel modelo = adminUser_tipo.ConsultarItemObj(id);
            return View(modelo);
        }

        public ActionResult Update(Usuario_tipoModel objUsuario_tipo)
        {
            adminUser_tipo.Update(objUsuario_tipo);
            return View("Index");
        }

        public ActionResult eliminar(int id)
        {
            Usuario_tipoModel modelo = adminUser_tipo.ConsultarItemObj(id);
            return View(modelo);
        }

        public ActionResult Delete_update(int usuario_id)
        {
            adminUser_tipo.Delete_update(usuario_id);
            return View("Index");
        }

        [HttpPost]
        public ActionResult insert(UsuariosModel objUsuarios)
        {
            adminUser_tipo.Insert(objUsuarios);
            return View("Index");
        }

        public JsonResult js_usuarios()
        {
            IEnumerable<Usuario_tipoModel> lista = adminUser_tipo.ConsultarAll();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult js_usuario_ById(int usuario_id)
        {
            IEnumerable<Usuario_tipoModel> lista = adminUser_tipo.ConsultarItem(usuario_id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult js_usuario_buscador(string term)
        {
            IEnumerable<Usuario_tipoModel> lista = adminUser_tipo.ConsultarBuscador(term);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Eval(String correo, String password)
        {
            UsuariosModel objUsuario = new UsuariosModel();
            if (ModelState.IsValid)
            {
                objUsuario = adminUsers.LoginProcess(correo, password);
                if (objUsuario.id.Equals(0))
                {
                    string dato = "nepel";
                    //return View("login");
                }
                else
                {
                    Response.Cookies.Add(new HttpCookie("usuario_id", objUsuario.id.ToString()));
                    Response.Cookies.Add(new HttpCookie("User_usuario", objUsuario.usuario));
                    Response.Cookies.Add(new HttpCookie("correo", objUsuario.correo));
                    Response.Cookies.Add(new HttpCookie("tipo_usuario_id", objUsuario.tipo_usuario_id.ToString()));
                    return RedirectToAction("Inicio", "Usuarios");
                }
            }
            return View("login");
        }

        public ActionResult Inicio()
        {
            return View();
        }
      

        public ActionResult Salir()
        {
            return View("Login");
        }

        public ActionResult perfil(int id)
        {
            Usuario_tipoModel modelo = adminUser_tipo.ConsultarItemObj(id);
            return View(modelo);
        }

    }
}