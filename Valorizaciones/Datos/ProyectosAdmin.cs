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
        public IEnumerable<ProyectosModel> ConsultarAll()
        {
            Conectar();
            List<ProyectosModel> lista = new List<ProyectosModel>();

            //string sql = "select * from proyectos where estado_eliminado = 0;";
            //string sql = "Select cui, proyecto,   pro.abreviatura, actividad_id, expediente_tecnico, total_obra, total_supervision, total_interferencia,total_gestion_proyecto, ubigeo,fecha_convocatoria, fecha_estimada_buena_pro, fecha_estimada_consentimiento, fecha_estimada_contrato, fecha_estimada_inicio, fecha_entrega_terreno,tiempo_ejecucion,estado_registro, tipo_proyecto, paquete" +
            // " from proyectos pro join tipo_proyectos tipop on pro.tipo_proyecto_id = tipop.id join paquetes pap on pro.paquete_id = pap.id WHERE estado_eliminado = 0;";

            string sql = "Select cui, proyecto, pro.abreviatura, expediente_tecnico, total_obra, total_supervision, total_interferencia,total_gestion_proyecto, ubigeo,fecha_convocatoria, fecha_estimada_buena_pro, fecha_estimada_consentimiento, fecha_estimada_contrato, fecha_estimada_inicio, fecha_entrega_terreno,tiempo_ejecucion,estado_registro, tipo_proyecto, paquete, actividad from proyectos pro join tipo_proyectos tipop on pro.tipo_proyecto_id = tipop.id join paquetes pap on pro.paquete_id = pap.id join actividades activ on pro.actividad_id = activ.id where estado_eliminado = 0;";

            SqlCommand comando = new SqlCommand(sql, cnn);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                ProyectosModel modelo = new ProyectosModel();

                //modelo.id = Convert.ToInt32(reader["id"]);
                modelo.cui = reader["cui"].ToString();
                modelo.proyecto = reader["proyecto"].ToString();
                modelo.abreviatura = reader["abreviatura"].ToString();
                modelo.tipo_proyecto = reader["tipo_proyecto"].ToString();
                modelo.paquete = reader["paquete"].ToString();
                modelo.actividad = reader["actividad"].ToString();
                modelo.expediente_tecnico = reader["expediente_tecnico"].ToString();

                modelo.total_obra = Decimal.Parse(reader["total_obra"].ToString());
                modelo.total_supervision = Decimal.Parse(reader["total_supervision"].ToString());
                modelo.total_interferencia = Decimal.Parse(reader["total_interferencia"].ToString());
                modelo.total_gestion_proyecto = Decimal.Parse(reader["total_gestion_proyecto"].ToString());
                modelo.ubigeo = reader["ubigeo"].ToString();

                modelo.fecha_convocatoria = reader["fecha_convocatoria"].ToString();
                modelo.fecha_estimada_buena_pro = reader["fecha_estimada_buena_pro"].ToString();
                modelo.fecha_estimada_consentimiento = reader["fecha_estimada_consentimiento"].ToString();
                modelo.fecha_estimada_contrato = reader["fecha_estimada_contrato"].ToString();
                modelo.fecha_estimada_inicio = reader["fecha_estimada_inicio"].ToString();
                modelo.fecha_entrega_terreno = reader["fecha_entrega_terreno"].ToString();

                modelo.tiempo_ejecucion = Convert.ToInt32(reader["tiempo_ejecucion"]);
                modelo.estado_registro = Convert.ToInt32(reader["estado_registro"]);
                lista.Add(modelo);
            }
            return lista;
        }
        public IEnumerable<ProyectosModel> Consultar()
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
                    ProyectosModel modelo = new ProyectosModel();

                    modelo.id = Convert.ToInt32(lector["id"]);
                    modelo.cui = lector["cui"].ToString();
                    modelo.proyecto = lector["proyecto"].ToString();
                    modelo.abreviatura = lector["abreviatura"].ToString();
                    modelo.tipo_proyecto_id = Convert.ToInt32(lector["tipo_proyecto_id"]);
                    modelo.paquete_id = Convert.ToInt32(lector["paquete_id"]);
                    modelo.actividad_id = Convert.ToInt32(lector["actividad_id"]);
                    modelo.expediente_tecnico = lector["expediente_tecnico"].ToString();

                    modelo.total_obra = Decimal.Parse(lector["total_obra"].ToString());
                    modelo.total_supervision = Decimal.Parse(lector["total_supervision"].ToString());
                    modelo.total_interferencia = Decimal.Parse(lector["total_interferencia"].ToString());
                    modelo.total_gestion_proyecto = Decimal.Parse(lector["total_gestion_proyecto"].ToString());
                    modelo.ubigeo = lector["ubigeo"].ToString();

                    modelo.fecha_convocatoria = lector["fecha_convocatoria"].ToString();
                    modelo.fecha_estimada_buena_pro = lector["fecha_estimada_buena_pro"].ToString();
                    modelo.fecha_estimada_consentimiento = lector["fecha_estimada_consentimiento"].ToString();
                    modelo.fecha_estimada_contrato = lector["fecha_estimada_contrato"].ToString();
                    modelo.fecha_estimada_inicio = lector["fecha_estimada_inicio"].ToString();
                    modelo.fecha_entrega_terreno = lector["fecha_entrega_terreno"].ToString();

                    modelo.tiempo_ejecucion = Convert.ToInt32(lector["tiempo_ejecucion"]);
                    modelo.estado_registro = Convert.ToInt32(lector["estado_registro"]);
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

        public ProyectosModel Proyecto_Byid(int id)
        {
            Conectar();
            ProyectosModel modelo = new ProyectosModel();
            try
            {
                string sql = "SELECT * FROM proyectos WHERE id = " + id;
                SqlCommand comando = new SqlCommand(sql, cnn);
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    modelo.id = Convert.ToInt32(lector["id"]);
                    modelo.cui = lector["cui"].ToString();
                    modelo.proyecto = lector["proyecto"].ToString();
                    modelo.abreviatura = lector["abreviatura"].ToString();
                    modelo.tipo_proyecto_id = Convert.ToInt32(lector["tipo_proyecto_id"]);
                    modelo.paquete_id = Convert.ToInt32(lector["paquete_id"]);
                    modelo.actividad_id = Convert.ToInt32(lector["actividad_id"]);
                    modelo.expediente_tecnico = lector["expediente_tecnico"].ToString();

                    modelo.total_obra = Decimal.Parse(lector["total_obra"].ToString());
                    modelo.total_supervision = Decimal.Parse(lector["total_supervision"].ToString());
                    modelo.total_interferencia = Decimal.Parse(lector["total_interferencia"].ToString());
                    modelo.total_gestion_proyecto = Decimal.Parse(lector["total_gestion_proyecto"].ToString());
                    modelo.ubigeo = lector["ubigeo"].ToString();

                    modelo.fecha_convocatoria = lector["fecha_convocatoria"].ToString();
                    modelo.fecha_estimada_buena_pro = lector["fecha_estimada_buena_pro"].ToString();
                    modelo.fecha_estimada_consentimiento = lector["fecha_estimada_consentimiento"].ToString();
                    modelo.fecha_estimada_contrato = lector["fecha_estimada_contrato"].ToString();
                    modelo.fecha_estimada_inicio = lector["fecha_estimada_inicio"].ToString();
                    modelo.fecha_entrega_terreno = lector["fecha_entrega_terreno"].ToString();

                    modelo.tiempo_ejecucion = Convert.ToInt32(lector["tiempo_ejecucion"]);
                    modelo.estado_registro = Convert.ToInt32(lector["estado_registro"]);
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
            return modelo;
        }

        public ProyectosModel ConsultarItem(int id)
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

        public IEnumerable<ProyectosModel> ConsultarBuscador(string parametro)
        {
            Conectar();
            List<ProyectosModel> lista = new List<ProyectosModel>();
            try
            {
                string sql = "SELECT *FROM proyectos where proyecto like  '%" + parametro + "%' OR cui like '" + parametro + "'";
                SqlCommand comando = new SqlCommand(sql, cnn);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ProyectosModel objPartidas = new ProyectosModel();
                    objPartidas.value = reader["proyecto"].ToString();
                    objPartidas.id = Convert.ToInt32(reader["id"]);
                    objPartidas.cui = reader["cui"].ToString();
                    lista.Add(objPartidas);
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
                Desconectar();
            }
        }

        public void Update(ProyectosModel objProyecto)
        {
            Conectar();
            try
            {
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
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
        }

        public void Delete(int id)
        {
            Conectar();
            try
            {
                string comandoSQL = "DELETE FROM proyectos WHERE id = @id";
                SqlCommand cmd = new SqlCommand(comandoSQL, cnn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }            
        }
        public void Delete_update(int id)
        {
            Conectar();
            string sql = "UPDATE proyectos SET estado_eliminado =  1 WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

    }
}