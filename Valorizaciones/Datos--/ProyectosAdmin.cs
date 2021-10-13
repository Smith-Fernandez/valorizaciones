using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class ProyectosAdmin:Conexion
    {

        public IEnumerable<Models.ProyectosModel> Consultar()
        {
            Conectar();
            List<ProyectosModel> lista = new List<ProyectosModel>();
            try
            {
                SqlCommand comando = new SqlCommand("sp_proyectos", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    ProyectosModel modelo = new ProyectosModel()
                    {
                        id = int.Parse(lector[0].ToString()),
                        cui = lector[1] + "",
                        proyecto = lector[2] + "",
                        abreviatura = lector[3] + "",
                        tipo_proyecto_id = int.Parse(lector[4] + ""),
                        paquete_id = int.Parse(lector[5] + ""),
                        actividad_id = int.Parse(lector[6] + ""),
                        expediente_tecnico = lector[7] + "",
                        total_obra = decimal.Parse(lector[8] + ""),
                        total_supervision = decimal.Parse(lector[9] + ""),
                        total_interferencia = decimal.Parse(lector[10] + ""),
                        total_gestion_proyecto = decimal.Parse(lector[11] + ""),
                        ubigeo = lector[12] + "",
                        fecha_convocatoria = lector[13] + "",
                        fecha_estimada_buena_pro = lector[14] + "",
                        fecha_estimada_consentimiento = lector[15] + "",
                        fecha_estimada_contrato = lector[16] + "",
                        fecha_estimada_inicio = lector[17] + "",
                        fecha_entrega_terreno = lector[18] + "",
                        tiempo_ejecucion = int.Parse(lector[19] + ""),
                        estado_registro = int.Parse(lector[20] + "")
                    };
                    lista.Add(modelo);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return lista;            
        }        

        public Models.ProyectosModel ConsultarItem(int id)
        {
            Conectar();

            ProyectosModel objProyecto = new ProyectosModel();
            try
            {
                string update = "SELECT *FROM proyectos where id = '" + id + "'";
                SqlCommand comando = new SqlCommand(update, cnn);
                
                SqlDataReader rdr = comando.ExecuteReader();
                while (rdr.Read())
                {
                    objProyecto.id  = Convert.ToInt32(rdr["id"]);
                    objProyecto.cui = rdr["cui"].ToString();
                    objProyecto.proyecto = rdr["proyecto"].ToString();
                    objProyecto.abreviatura = rdr["abreviatura"].ToString();
                    objProyecto.tipo_proyecto_id = Convert.ToInt32(rdr["tipo_proyecto_id"]);
                    objProyecto.paquete_id = Convert.ToInt32(rdr["paquete_id"]);
                    objProyecto.actividad_id = Convert.ToInt32(rdr["actividad_id"]);
                    objProyecto.expediente_tecnico = rdr["expediente_tecnico"].ToString();

                    objProyecto.total_obra = Decimal.Parse(rdr["total_obra"].ToString());
                    objProyecto.total_supervision = Decimal.Parse(rdr["total_supervision"].ToString());
                    objProyecto.total_interferencia = Decimal.Parse(rdr["total_interferencia"].ToString());
                    objProyecto.total_gestion_proyecto = Decimal.Parse(rdr["total_gestion_proyecto"].ToString());
                    objProyecto.ubigeo = rdr["ubigeo"].ToString();

                    objProyecto.fecha_convocatoria = rdr["fecha_convocatoria"].ToString();
                    objProyecto.fecha_estimada_buena_pro = rdr["fecha_estimada_buena_pro"].ToString();
                    objProyecto.fecha_estimada_consentimiento = rdr["fecha_estimada_consentimiento"].ToString();
                    objProyecto.fecha_estimada_contrato = rdr["fecha_estimada_contrato"].ToString();
                    objProyecto.fecha_estimada_inicio = rdr["fecha_estimada_inicio"].ToString();
                    objProyecto.fecha_entrega_terreno = rdr["fecha_entrega_terreno"].ToString();

                    objProyecto.tiempo_ejecucion = Convert.ToInt32(rdr["tiempo_ejecucion"]);
                    objProyecto.estado_registro = Convert.ToInt32(rdr["estado_registro"]);
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return objProyecto;
        }

        public void Guardar(ProyectosModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_proyectos_guardar", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@cui", modelo.cui);
                comando.Parameters.AddWithValue("@proyecto", modelo.proyecto);
                comando.Parameters.AddWithValue("@abreviatura", modelo.abreviatura);
                comando.Parameters.AddWithValue("@tipo_proyecto_id", modelo.tipo_proyecto_id);
                comando.Parameters.AddWithValue("@paquete_id", modelo.paquete_id);
                comando.Parameters.AddWithValue("@actividad_id", modelo.actividad_id);
                comando.Parameters.AddWithValue("@expediente_tecnico", modelo.expediente_tecnico);
                comando.Parameters.AddWithValue("@total_obra", modelo.total_obra);
                comando.Parameters.AddWithValue("@total_supervision", modelo.total_supervision);
                comando.Parameters.AddWithValue("@total_interferencia", modelo.total_interferencia);

                comando.Parameters.AddWithValue("@total_gestion_proyecto", modelo.total_gestion_proyecto);
                comando.Parameters.AddWithValue("@ubigeo", modelo.ubigeo);
                comando.Parameters.AddWithValue("@fecha_convocatoria", modelo.fecha_convocatoria);
                comando.Parameters.AddWithValue("@fecha_estimada_buena_pro", modelo.fecha_estimada_buena_pro);
                comando.Parameters.AddWithValue("@fecha_estimada_consentimiento", modelo.fecha_estimada_consentimiento);
                comando.Parameters.AddWithValue("@fecha_estimada_contrato", modelo.fecha_estimada_contrato);
                comando.Parameters.AddWithValue("@fecha_estimada_inicio", modelo.fecha_estimada_inicio);
                comando.Parameters.AddWithValue("@fecha_entrega_terreno", modelo.fecha_entrega_terreno);
                comando.Parameters.AddWithValue("@tiempo_ejecucion", modelo.tiempo_ejecucion);
                comando.Parameters.AddWithValue("@estado_registro", modelo.estado_registro);

                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            finally
            {

            }
        }

        public void Update(ProyectosModel objProyecto)
        {
            Conectar();

                //              
                //  fecha_estimada_buena_pro fecha_estimada_consentimiento   fecha_estimada_contrato fecha_estimada_inicio   fecha_entrega_terreno 
                //    
                
            string comandoSQL = " Update proyectos set " +
                " cui = @cui, " +
                " proyecto = @proyecto, " +
                " abreviatura = @abreviatura, " +
                " expediente_tecnico = @expediente_tecnico, " +
                " tipo_proyecto_id = @tipo_proyecto_id, " +
                " paquete_id = @paquete_id, " +
                " actividad_id = @actividad_id, " +
                " total_obra = @total_obra, " +
                " total_supervision = @total_supervision, " +
                " total_interferencia = @total_interferencia, " +
                " total_gestion_proyecto = @total_gestion_proyecto, " +
                " tiempo_ejecucion = @tiempo_ejecucion, " +
                " estado_registro = @estado_registro, " +
                " fecha_convocatoria = @fecha_convocatoria, " +
                
                " ubigeo = @ubigeo " +
                " WHERE id = @id";

            SqlCommand cmd = new SqlCommand(comandoSQL, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@cui", objProyecto.cui);
            cmd.Parameters.AddWithValue("@proyecto", objProyecto.proyecto);
            cmd.Parameters.AddWithValue("@abreviatura", objProyecto.abreviatura);
            cmd.Parameters.AddWithValue("@expediente_tecnico", objProyecto.expediente_tecnico);
            cmd.Parameters.AddWithValue("@ubigeo", objProyecto.ubigeo);
            cmd.Parameters.AddWithValue("@tipo_proyecto_id", objProyecto.tipo_proyecto_id);
            cmd.Parameters.AddWithValue("@paquete_id", objProyecto.paquete_id);
            cmd.Parameters.AddWithValue("@actividad_id", objProyecto.actividad_id);
            cmd.Parameters.AddWithValue("@total_obra", objProyecto.total_obra);
            cmd.Parameters.AddWithValue("@total_supervision", objProyecto.total_supervision);
            cmd.Parameters.AddWithValue("@total_interferencia", objProyecto.total_interferencia);
            cmd.Parameters.AddWithValue("@total_gestion_proyecto", objProyecto.total_gestion_proyecto);
            cmd.Parameters.AddWithValue("@tiempo_ejecucion", objProyecto.tiempo_ejecucion);
            cmd.Parameters.AddWithValue("@estado_registro", objProyecto.estado_registro);
            cmd.Parameters.AddWithValue("@fecha_convocatoria", objProyecto.fecha_convocatoria);
            
            cmd.Parameters.AddWithValue("@id", objProyecto.id);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            Conectar();
            string comandoSQL = "DELETE FROM proyectos WHERE id = @id";
            SqlCommand cmd = new SqlCommand(comandoSQL, cnn);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

    }
}