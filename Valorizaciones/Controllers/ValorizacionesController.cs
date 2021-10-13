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
    public class ValorizacionesController : Controller

    {
        ValorizacionesAdmin adminValorizaciones = new ValorizacionesAdmin();
        Programacion_ejecucionesAdmin adminProgramacion_ejecucion = new Programacion_ejecucionesAdmin();
        VariablesAdmin variables = new VariablesAdmin();
        // GET: Valorizaciones
        public ActionResult EvaluarEjecuciones(string id)
        {
            int programacion_ejecuciones_id = 0;
            string[] stringSeparators = new string[] { variables.Param_URL() };
            string[] words = id.Split(stringSeparators, StringSplitOptions.None);

            string cadena_0 = words[0];
            string numero_orden = words[1];
            string programacion_id = words[2];

            string[] stringCadena_0 = new string[] { variables.Param_URL_J() };
            string[] words_2 = cadena_0.Split(stringCadena_0, StringSplitOptions.None);

            string contrato_id = words_2[1];
            programacion_ejecuciones_id = adminProgramacion_ejecucion.ConsultarByProgramacion(programacion_id);

            //if (programacion_ejecuciones_id == 0)
            //{
            //    //insert programacion_ejecuciones
            //    Programacion_ejecucionesModel objProgramacionEjecucion = new Programacion_ejecucionesModel();
            //    objProgramacionEjecucion.programacion_id = Convert.ToInt32(programacion_id);
            //    objProgramacionEjecucion.ejecucion = 1;
            //    objProgramacionEjecucion.amortizacion = 0;
            //    var DateAndTime = DateTime.Now;
            //    var Date = DateAndTime.Date.ToString("yyyy-MM-dd");
            //    objProgramacionEjecucion.fecha = Date;
            //    adminProgramacion_ejecucion.Insert(objProgramacionEjecucion);

            //    programacion_ejecuciones_id = adminProgramacion_ejecucion.ConsultarByProgramacion(programacion_id);
            //}
            return RedirectToAction("Index", new { id = variables.Param_URL_J() + contrato_id + variables.Param_URL() + numero_orden + variables.Param_URL() + programacion_id + variables.Param_URL() + programacion_ejecuciones_id });
        }

        public ActionResult EvaluarEjecucionesParaResumen(string id)
        {
            int programacion_ejecuciones_id = 0;
            string[] stringSeparators = new string[] { variables.Param_URL() };
            string[] words = id.Split(stringSeparators, StringSplitOptions.None);

            string cadena_0 = words[0];
            string numero_orden = words[1];
            string programacion_id = words[2];

            string[] stringCadena_0 = new string[] { variables.Param_URL_J() };
            string[] words_2 = cadena_0.Split(stringCadena_0, StringSplitOptions.None);

            string contrato_id = words_2[1];
            programacion_ejecuciones_id = adminProgramacion_ejecucion.ConsultarByProgramacion(programacion_id);
           
            return RedirectToAction("Resumen", new { id = variables.Param_URL_J() + contrato_id + variables.Param_URL() + numero_orden + variables.Param_URL() + programacion_id + variables.Param_URL() + programacion_ejecuciones_id });
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pdf_plantilla(){
            return View();
        }

        public ActionResult Resumen()
        {
            return View();
        }

        public ActionResult Pdf_resumen()
        {
            return View();
        }

        public JsonResult js_valorizaciones_ByProgramacion_id(string id)
        {
            string[] stringSeparators = new string[] { variables.Param_URL() };
            string[] words = id.Split(stringSeparators, StringSplitOptions.None);

            int contrato_id = Convert.ToInt32(words[0]);
            int programacion_id = Convert.ToInt32(words[1]);
            int programacion_ejecucion_id = Convert.ToInt32(words[2]);
            IEnumerable<ValorizacionTrabajoModel> lista = adminValorizaciones.ConsultarAll(contrato_id, programacion_id, programacion_ejecucion_id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Datos_resumen(int id)
        {
            IEnumerable<ResumenModel> lista = adminValorizaciones.Resumen(id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }        

        public JsonResult Valorizaciones_Sin_Formato(string id)
        {
            string[] stringSeparators = new string[] { variables.Param_URL() };
            string[] words = id.Split(stringSeparators, StringSplitOptions.None);

            int contrato_id = Convert.ToInt32(words[0]);
            int programacion_id = Convert.ToInt32(words[1]);
            int programacion_ejecucion_id = Convert.ToInt32(words[2]);
            IEnumerable<ValidacionSinFormatoModel> lista = adminValorizaciones.Valorizaciones_Sin_Formato(contrato_id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Valorizaciones_ByEjecucion_id(int id)
        {            
            IEnumerable<Valorizacion_ejecucionModel> lista = adminValorizaciones.Valorizaciones_ByEjecucion_id(id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult ValorizacionesByContratoByProgramacion(int id)
        {
            IEnumerable<ValorizacionesSumaModel> lista = adminValorizaciones.ValorizacionesByContratoByProgramacion(id);
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(Programacion_valorizaciones_maestroDetalleModel model)
        {
            Programacion_ejecucionesModel objProgramacion_ejecuciones = new Programacion_ejecucionesModel();
            objProgramacion_ejecuciones.id                          = model.id;
            objProgramacion_ejecuciones.programacion_id             = model.programacion_id;
            objProgramacion_ejecuciones.amortizacion                = model.amortizacion;
            objProgramacion_ejecuciones.fecha                       = model.fecha;

            objProgramacion_ejecuciones.contratista_id              = model.contratista_id;
            objProgramacion_ejecuciones.supervisor_id               = model.supervisor_id;
                
            if (model.id == 0)
            {
                adminProgramacion_ejecucion.Insert(objProgramacion_ejecuciones);
                model.id = adminProgramacion_ejecucion.MaximoId();
            }
            else
            {
                if (model.tipo_usuario == 4) {//contratista
                    adminProgramacion_ejecucion.Update(objProgramacion_ejecuciones);
                }
                else if (model.tipo_usuario == 3) //supervisor
                {
                    adminProgramacion_ejecucion.Update_supervisor(objProgramacion_ejecuciones);
                }
            }


            if (model.tipo_usuario == 3) //supervisor
            {            
                //esto sera para encontrar condiciones de valorizacion Supervisor
                foreach (var ac in model.valorizaciones)
                {
                    if (ac.aprobacion_contratista == 0)
                    {
                        //regreso el estado de la ejecucion anterior a su normalidad
                        Programacion_ejecucionesModel objProgramacion_ejecuciones2 = new Programacion_ejecucionesModel();
                        objProgramacion_ejecuciones2.id = model.id;
                        objProgramacion_ejecuciones2.supervisor_id = 0;
                        adminProgramacion_ejecucion.Update_supervisor(objProgramacion_ejecuciones2);

                        //ingreso nueva ejecucion (La no concilidad generada por el supervisor)
                        objProgramacion_ejecuciones.valorizacion_supervisor_id = model.supervisor_id;
                        adminProgramacion_ejecucion.Insert(objProgramacion_ejecuciones);
                        model.id = adminProgramacion_ejecucion.MaximoId();
                        break;
                    }
                }
            }

            foreach (var oc in model.valorizaciones)
            {
                ValorizacionesModel objValorizaciones       = new ValorizacionesModel();
                objValorizaciones.programacion_ejecucion_id = model.id;
                objValorizaciones.contrato_partida_id       = oc.contrato_partida_id;
                objValorizaciones.cantidad                  = oc.cantidad;
                objValorizaciones.aprobacion_contratista    = oc.aprobacion_contratista;
                objValorizaciones.id                        = oc.id;
                
                //inserta, para el contratista.
                if (oc.id == 0)
                {
                    adminValorizaciones.insert(objValorizaciones);
                }
                else//para el contratista
                {
                    adminValorizaciones.Update(objValorizaciones);
                }
            }
            //return View();
            return RedirectToAction("Index", "Programaciones", new { id = variables.Param_URL() + model.contrato_id });
        }

        public ActionResult Curva_s()
        {
            return View();
        }

    }
}