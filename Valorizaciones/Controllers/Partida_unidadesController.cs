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
    public class Partida_unidadesController : Controller
    {

        PartidasAdmin adminPartidas = new PartidasAdmin();
        // GET: Partida_unidades
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult modificar(int id)
        {
            Partida_unidadesModel modelo = adminPartidas.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult perfil(int id)
        {
            Partida_unidadesModel modelo = adminPartidas.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult eliminar(int id)
        {
            Partida_unidadesModel modelo = adminPartidas.ConsultarItem(id);
            return View(modelo);
        }

        public ActionResult prueba()
        {
            //Partida_unidadesModel modelo = adminPartidas.ConsultarItem(id);
            return View();
        }
    }
}