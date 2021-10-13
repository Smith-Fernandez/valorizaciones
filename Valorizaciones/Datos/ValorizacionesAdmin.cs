using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class ValorizacionesAdmin : Conexion
    {
        public IEnumerable<ValorizacionTrabajoModel> ConsultarAll(int contrato_id, int programacion_id, int programacion_ejecucion_id)
        {
            Conectar();
            List<ValorizacionTrabajoModel> lista = new List<ValorizacionTrabajoModel>();

            try
            {
                string sql = "SELECT con.adelanto_directo, con.gastos_generales, con.gastos_otros, con.utilidad, par.partida, " +
                "ISNULL(pgr.contratista_id, 0) AS contratista_id, ISNULL(pgr.supervisor_id, 0) AS supervisor_id, ISNULL(pgr.valorizacion_supervisor_id, 0) AS valorizacion_supervisor_id, cpa.codigo, cpa.cantidad cantidad, cpa.precio, " +
                "ISNULL(val.cantidad, 0) AS cantidad_valorizado, ISNULL(val.aprobacion_contratista, 0) AS aprobacion_contratista, par.id partida_id, " +
                "cpa.id contrato_partida_id, ISNULL(val.id, 0) AS valorizacion_id, ISNULL(pgr.id, 0) AS programacion_ejecucion_id, ISNULL(pgr.amortizacion, 0) AS amortizacion " +
                "FROM contrato_partidas cpa " +
                "JOIN contratos con ON con.id = cpa.contrato_id left " +
                "JOIN partidas par ON par.id = cpa.partida_id left " +
                "JOIN valorizaciones val ON val.contrato_partida_id = cpa.id AND val.programacion_ejecucion_id = " + programacion_ejecucion_id +
                "LEFT JOIN programacion_ejecuciones pgr ON pgr.id = val.programacion_ejecucion_id " +
                "LEFT JOIN programaciones pro ON pro.id = pgr.programacion_id AND pro.id = " + programacion_id + " WHERE cpa.contrato_id = " + contrato_id + " ORDER BY cpa.codigo ";
                SqlCommand comando = new SqlCommand(sql, cnn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ValorizacionTrabajoModel objValorizaciones = new ValorizacionTrabajoModel();
                    objValorizaciones.partida = reader["partida"].ToString();
                    objValorizaciones.codigo = reader["codigo"].ToString();
                    objValorizaciones.cantidad = Decimal.Parse(reader["cantidad"].ToString());
                    objValorizaciones.precio = Decimal.Parse(reader["precio"].ToString());
                    objValorizaciones.cantidad_valorizado = Decimal.Parse(reader["cantidad_valorizado"].ToString());
                    objValorizaciones.partida_id = Convert.ToInt32(reader["partida_id"]);
                    objValorizaciones.contrato_partida_id = Convert.ToInt32(reader["contrato_partida_id"]);
                    objValorizaciones.aprobacion_contratista = Convert.ToInt32(reader["aprobacion_contratista"]);
                    objValorizaciones.valorizacion_id = Convert.ToInt32(reader["valorizacion_id"]);
                    objValorizaciones.amortizacion = Convert.ToInt32(reader["amortizacion"]);
                    objValorizaciones.programacion_ejecucion_id = Convert.ToInt32(reader["programacion_ejecucion_id"]);
                    objValorizaciones.contratista_id = Convert.ToInt32(reader["contratista_id"]);
                    objValorizaciones.supervisor_id = Convert.ToInt32(reader["supervisor_id"]);
                    objValorizaciones.valorizacion_supervisor_id = Convert.ToInt32(reader["valorizacion_supervisor_id"]);                    

                    objValorizaciones.adelanto_directo = Convert.ToInt32(reader["adelanto_directo"]);
                    objValorizaciones.gastos_generales = Convert.ToInt32(reader["gastos_generales"]);
                    objValorizaciones.gastos_otros = Convert.ToInt32(reader["gastos_otros"]);
                    objValorizaciones.utilidad = Convert.ToInt32(reader["utilidad"]);
                    lista.Add(objValorizaciones);
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

        public IEnumerable<ValorizacionesSumaModel> ValorizacionesByContrato(int contrato_id)
        {
            Conectar();
            List<ValorizacionesSumaModel> lista = new List<ValorizacionesSumaModel>();
            try
            {
                string sql = "SELECT pro.id programacion_id, pro.fecha, val.cantidad, cpa.precio " +
                "from contrato_partidas cpa " +
                "left join valorizaciones val on val.contrato_partida_id = cpa.id " +
                "left join programacion_ejecuciones pgr on pgr.id = val.programacion_ejecucion_id " +
                "left join programaciones pro on pro.id = pgr.programacion_id " +
                "WHERE cpa.contrato_id = " + contrato_id + " and pro.eliminado = 0 ORDER BY pro.id, val.cantidad";
                SqlCommand comando = new SqlCommand(sql, cnn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ValorizacionesSumaModel objValorizaciones = new ValorizacionesSumaModel();
                    objValorizaciones.id = Convert.ToInt32(reader["programacion_id"]);
                    objValorizaciones.programacion_id = Convert.ToInt32(reader["programacion_id"]);
                    objValorizaciones.fecha = reader["fecha"].ToString();
                    objValorizaciones.cantidad = Decimal.Parse(reader["cantidad"].ToString());
                    objValorizaciones.precio = Decimal.Parse(reader["precio"].ToString());
                    lista.Add(objValorizaciones);
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

        public IEnumerable<ValorizacionesSumaModel> ValorizacionesByContratoByProgramacion(int contrato_id)
        {
            Conectar();
            List<ValorizacionesSumaModel> lista = new List<ValorizacionesSumaModel>();
            try
            {
                string sql = "select sum(val.cantidad * cpa.precio) total, pro.id " +
                "from contrato_partidas cpa " +
                "left join valorizaciones val on val.contrato_partida_id = cpa.id " +
                "left join programacion_ejecuciones pgr on pgr.id = val.programacion_ejecucion_id  " +
                "left join programaciones pro on pro.id = pgr.programacion_id " +
                "WHERE cpa.contrato_id = " + contrato_id + " and pro.eliminado = 0  " +
                "group by pro.id " +
                "order by pro.id";
                SqlCommand comando = new SqlCommand(sql, cnn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ValorizacionesSumaModel objValorizaciones = new ValorizacionesSumaModel();
                    objValorizaciones.id = Convert.ToInt32(reader["id"]);
                    objValorizaciones.total = Decimal.Parse(reader["total"].ToString());
                    lista.Add(objValorizaciones);
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

        public IEnumerable<ValidacionSinFormatoModel> Valorizaciones_Sin_Formato(int contrato_id)
        {
            Conectar();
            List<ValidacionSinFormatoModel> lista = new List<ValidacionSinFormatoModel>();
            try
            {
                string sql = "SELECT cpa.codigo, par.partida, cpa.partida_id, ISNULL(val.programacion_ejecucion_id, 0) AS programacion_ejecucion_id, ISNULL(val.cantidad, 0) AS cantidad, ISNULL(cpa.precio, 0) AS precio " +
                "FROM partidas par INNER JOIN contrato_partidas cpa ON par.id = cpa.partida_id " +
                "LEFT JOIN valorizaciones val ON val.contrato_partida_id = cpa.id " +
                "LEFT JOIN programacion_ejecuciones pgr ON pgr.id = val.programacion_ejecucion_id  AND pgr.contratista_id != 0 AND pgr.supervisor_id != 0 AND pgr.valorizacion_supervisor_id = 0 " +
                "WHERE cpa.contrato_id = " + contrato_id + 
                "ORDER BY cpa.id, val.programacion_ejecucion_id, cpa.codigo";
                SqlCommand comando = new SqlCommand(sql, cnn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ValidacionSinFormatoModel objValorizaciones = new ValidacionSinFormatoModel();

                    objValorizaciones.codigo = reader["codigo"].ToString();
                    objValorizaciones.partida = reader["partida"].ToString();
                    objValorizaciones.partida_id = Convert.ToInt32(reader["partida_id"]);
                    objValorizaciones.programacion_ejecucion_id = (reader["programacion_ejecucion_id"] == null) ? 0 : Convert.ToInt32(reader["programacion_ejecucion_id"]);
                    objValorizaciones.cantidad = (reader["cantidad"] == null) ? 0 : Decimal.Parse(reader["cantidad"].ToString());
                    objValorizaciones.precio = (reader["precio"] == null) ? 0 : Decimal.Parse(reader["precio"].ToString());
                    lista.Add(objValorizaciones);
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

        public IEnumerable<Valorizacion_ejecucionModel> Valorizaciones_ByEjecucion_id(int ejecucion_id)
        {
            Conectar();
            List<Valorizacion_ejecucionModel> lista = new List<Valorizacion_ejecucionModel>();
            try
            {
                string sql = "SELECT pge.programacion_id, pge.supervisor_id, cpa.precio, val.cantidad, cpa.partida_id, val.contrato_partida_id, val.programacion_ejecucion_id FROM contrato_partidas cpa JOIN valorizaciones val ON cpa.id = val.contrato_partida_id JOIN programacion_ejecuciones pge ON pge.id = val.programacion_ejecucion_id WHERE val.programacion_ejecucion_id = " + ejecucion_id;
                SqlCommand comando = new SqlCommand(sql, cnn);
                SqlDataReader reader = comando.ExecuteReader();                           
                while (reader.Read())
                {
                    Valorizacion_ejecucionModel objValorizaciones = new Valorizacion_ejecucionModel();

                    objValorizaciones.programacion_id           = Convert.ToInt32(reader["programacion_id"]);
                    objValorizaciones.supervisor_id             = Convert.ToInt32(reader["supervisor_id"]);
                    objValorizaciones.precio                    = Decimal.Parse(reader["precio"].ToString());
                    objValorizaciones.cantidad                  = Decimal.Parse(reader["cantidad"].ToString());
                    objValorizaciones.partida_id                = Convert.ToInt32(reader["partida_id"]);
                    objValorizaciones.contrato_partida_id       = Convert.ToInt32(reader["contrato_partida_id"]);
                    objValorizaciones.programacion_ejecucion_id = Convert.ToInt32(reader["programacion_ejecucion_id"]);
                    lista.Add(objValorizaciones);
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

        public IEnumerable<ResumenModel> Resumen(int id)
        {
            Conectar();
            List<ResumenModel> lista = new List<ResumenModel>();

            try
            {
                string sql = "SELECT sum(val.cantidad * cpa.precio) resumen, pge.id " +
                "FROM contrato_partidas cpa " +
                "JOIN valorizaciones val ON cpa.id = val.contrato_partida_id " +
                "JOIN programacion_ejecuciones pge ON pge.id = val.programacion_ejecucion_id " +
                "JOIN programaciones pro ON pro.id = pge.programacion_id " +
                "WHERE pro.contrato_id = " + id + " " +
                "GROUP BY pge.id ORDER BY id";
                SqlCommand comando = new SqlCommand(sql, cnn);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ResumenModel objResumen = new ResumenModel();
                    objResumen.Id = Convert.ToInt32(reader["id"].ToString());
                    objResumen.Resumen = Decimal.Parse(reader["resumen"].ToString());
                    lista.Add(objResumen);
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

        public void insert(ValorizacionesModel objValorizacion)
        {
            Conectar();
            try
            {
                string sql = "INSERT INTO valorizaciones (programacion_ejecucion_id, contrato_partida_id, cantidad, aprobacion_contratista) VALUES (" + objValorizacion.programacion_ejecucion_id + ", " + objValorizacion.contrato_partida_id + ",	" + objValorizacion.cantidad + ",	" + objValorizacion.aprobacion_contratista + ")";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }                        
        }

        public void Update(ValorizacionesModel objValorizacion)
        {
            Conectar();
            try
            {
                string sql = "UPDATE valorizaciones SET cantidad = " + objValorizacion.cantidad + ", aprobacion_contratista = " + objValorizacion.aprobacion_contratista + " WHERE id = " + objValorizacion.id;
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }            
        }

    }
}



