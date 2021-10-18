using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class ContratosAdmin:Conexion
    {
        public IEnumerable<ContratosModel> ConsultarAll()
        {
            Conectar();            
            List<ContratosModel> lista = new List<ContratosModel>();
            try{
                string sql = "SELECT * FROM contratos";
                SqlCommand comando = new SqlCommand(sql, cnn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ContratosModel objContratos = new ContratosModel();
                    objContratos.id = Convert.ToInt32(reader["id"]);
                    objContratos.proyecto_id = Convert.ToInt32(reader["proyecto_id"]);
                    objContratos.ruc = reader["ruc"].ToString();
                    objContratos.razon_social = reader["razon_social"].ToString();
                    objContratos.numero = reader["numero"].ToString();
                    objContratos.fecha = reader["fecha"].ToString();
                    objContratos.plazo = Decimal.Parse(reader["plazo"].ToString());
                    objContratos.presupuesto_referencial = Decimal.Parse(reader["presupuesto_referencial"].ToString());
                    objContratos.presupuesto_contratado = Decimal.Parse(reader["presupuesto_contratado"].ToString());
                    objContratos.adelanto_directo = Decimal.Parse(reader["adelanto_directo"].ToString());
                    objContratos.gastos_generales = Decimal.Parse(reader["gastos_generales"].ToString());
                    objContratos.gastos_otros = Decimal.Parse(reader["gastos_otros"].ToString());
                    objContratos.utilidad = Decimal.Parse(reader["utilidad"].ToString());
                    objContratos.fecha_inicio_obra = reader["fecha_inicio_obra"].ToString();
                    objContratos.fecha_inicio_obra_max = reader["fecha_inicio_obra_max"].ToString();
                    objContratos.fecha_entrega_terreno = reader["fecha_entrega_terreno"].ToString();
                    objContratos.porcentaje_ganador = Decimal.Parse(reader["porcentaje_ganador"].ToString());

                    objContratos.estado = Convert.ToInt32(reader["estado"]);
                    lista.Add(objContratos);
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
        public IEnumerable<Cabecera_resumenModel> Cabecera_resumen(int id)
        {
            Conectar();
            List<Cabecera_resumenModel> lista = new List<Cabecera_resumenModel>();
            try
            {
                string sql = "SELECT usu.usuario, pro.proyecto, pro.abreviatura, con.presupuesto_referencial, con.presupuesto_contratado, usu.tipo_usuario_id " +
                "FROM proyectos pro " +
                "JOIN contratos con ON con.proyecto_id = pro.id " +
                "JOIN contrato_usuarios cus ON con.id = cus.contrato_id " +
                "JOIN usuarios usu ON usu.id = cus.usuario_id " +
                "WHERE con.id = " + id;
                SqlCommand comando = new SqlCommand(sql, cnn);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cabecera_resumenModel objContratos = new Cabecera_resumenModel();
                    objContratos.Usuario = reader["usuario"].ToString();
                    objContratos.Proyecto = reader["proyecto"].ToString();
                    objContratos.Abreviatura = reader["abreviatura"].ToString();
                    objContratos.presupuesto_referencial = Decimal.Parse(reader["presupuesto_referencial"].ToString());
                    objContratos.presupuesto_contratado = Decimal.Parse(reader["presupuesto_contratado"].ToString());
                    objContratos.Tipo_usuario_id = Convert.ToInt32(reader["tipo_usuario_id"].ToString());
                    lista.Add(objContratos);
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
        public ContratosModel Contrato_Byid(int id)
        {
            Conectar();
            ContratosModel objContratos = new ContratosModel();

            try
            {
                string sql = "SELECT * FROM contratos WHERE id = " + id;
                SqlCommand comando = new SqlCommand(sql, cnn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    objContratos.id = Convert.ToInt32(reader["id"]);
                    objContratos.proyecto_id = Convert.ToInt32(reader["proyecto_id"]);
                    objContratos.ruc = reader["ruc"].ToString();
                    objContratos.razon_social = reader["razon_social"].ToString();
                    objContratos.numero = reader["numero"].ToString();
                    objContratos.fecha = reader["fecha"].ToString();
                    objContratos.presupuesto_referencial = Decimal.Parse(reader["presupuesto_referencial"].ToString());
                    objContratos.presupuesto_contratado = Decimal.Parse(reader["presupuesto_contratado"].ToString());
                    objContratos.plazo = Decimal.Parse(reader["plazo"].ToString());

                    objContratos.adelanto_directo = Decimal.Parse(reader["adelanto_directo"].ToString());
                    objContratos.gastos_generales = Decimal.Parse(reader["gastos_generales"].ToString());
                    objContratos.gastos_otros = Decimal.Parse(reader["gastos_otros"].ToString());
                    objContratos.utilidad = Decimal.Parse(reader["utilidad"].ToString());
                    objContratos.fecha_inicio_obra = reader["fecha_inicio_obra"].ToString();
                    objContratos.fecha_inicio_obra_max = reader["fecha_inicio_obra_max"].ToString();
                    objContratos.fecha_entrega_terreno = reader["fecha_entrega_terreno"].ToString();
                    objContratos.presupuesto_notas = reader["presupuesto_notas"].ToString();
                    objContratos.estado = Convert.ToInt32(reader["estado"]);
                    objContratos.porcentaje_ganador = Decimal.Parse(reader["porcentaje_ganador"].ToString());
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
            return objContratos;
        }        
        public IEnumerable<Contrato_proyectosModel> ConsultarBuscador(string parametro)
        {
            Conectar();
            List<Contrato_proyectosModel> lista = new List<Contrato_proyectosModel>();

            try
            {
                string sql = "SELECT pro.id proyecto_id, con.id contrato_id, pro.proyecto, pro.abreviatura, pro.cui, pro.expediente_tecnico FROM proyectos pro JOIN contratos con ON pro.id = con.proyecto_id WHERE proyecto LIKE '%" + parametro + "%'";
                SqlCommand comando = new SqlCommand(sql, cnn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Contrato_proyectosModel objContrato_proyectos = new Contrato_proyectosModel();

                    objContrato_proyectos.proyecto_id = Convert.ToInt32(reader["proyecto_id"]);
                    objContrato_proyectos.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                    objContrato_proyectos.value = reader["proyecto"].ToString();
                    lista.Add(objContrato_proyectos);
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
        public IEnumerable<Contrato_proyectosModel> Contrato_proyectos_All()
        {
            Conectar();
            List<Contrato_proyectosModel> lista = new List<Contrato_proyectosModel>();

            try
            {
                string sql = "SELECT pro.id proyecto_id, " +
                "pro.proyecto, " +
                "con.id contrato_id, " +
                "con.ruc, con.razon_social, con.numero numero, con.fecha fecha,  ISNULL(con.presupuesto_referencial, 0) AS presupuesto_referencial, ISNULL(con.presupuesto_contratado, 0) AS presupuesto_contratado, " +
                "con.adelanto_directo, " +
                "con.porcentaje_ganador, " +
                "plazo,	gastos_generales, gastos_otros, utilidad, " +
                "fecha_inicio_obra, fecha_inicio_obra_max, con.fecha_entrega_terreno fecha_entrega_terreno, estado FROM contratos con INNER JOIN proyectos pro ON pro.id = con.proyecto_id where con.estado= 1";
                SqlCommand comando = new SqlCommand(sql, cnn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Contrato_proyectosModel objContratos = new Contrato_proyectosModel();
                    objContratos.proyecto_id = Convert.ToInt32(reader["proyecto_id"]);
                    objContratos.proyecto = reader["proyecto"].ToString();
                    objContratos.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                    objContratos.ruc = reader["ruc"].ToString();
                    objContratos.razon_social = reader["razon_social"].ToString();
                    objContratos.numero = reader["numero"].ToString();

                    objContratos.fecha = reader["fecha"].ToString();
                    objContratos.plazo = Decimal.Parse(reader["plazo"].ToString());
                    objContratos.presupuesto_referencial = Decimal.Parse(reader["presupuesto_referencial"].ToString());
                    objContratos.presupuesto_contratado = Decimal.Parse(reader["presupuesto_contratado"].ToString());

                    objContratos.adelanto_directo = Decimal.Parse(reader["adelanto_directo"].ToString());
                    objContratos.gastos_generales = Decimal.Parse(reader["gastos_generales"].ToString());
                    objContratos.gastos_otros = Decimal.Parse(reader["gastos_otros"].ToString());
                    objContratos.utilidad = Decimal.Parse(reader["utilidad"].ToString());
                    objContratos.fecha_inicio_obra = reader["fecha_inicio_obra"].ToString();
                    objContratos.fecha_inicio_obra_max = reader["fecha_inicio_obra_max"].ToString();
                    objContratos.fecha_entrega_terreno = reader["fecha_entrega_terreno"].ToString();
                    objContratos.porcentaje_ganador = Decimal.Parse(reader["porcentaje_ganador"].ToString());

                    objContratos.estado = Convert.ToInt32(reader["estado"]);
                    lista.Add(objContratos);
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
        public IEnumerable<Contrato_proyectosModel> Contratos_ByUsuario(int id)
        {
            Conectar();
            List<Contrato_proyectosModel> lista = new List<Contrato_proyectosModel>();
            try
            {
                string sql = "SELECT pro.id proyecto_id, " +
                "pro.proyecto, " +
                "con.id contrato_id, " +
                "con.ruc, con.razon_social, con.numero numero, con.fecha fecha, ISNULL(con.presupuesto_referencial, 0) AS presupuesto_referencial, ISNULL(con.presupuesto_contratado, 0) AS presupuesto_contratado, " +
                "con.adelanto_directo, " +
                "con.porcentaje_ganador, " +
                "plazo,	gastos_generales, gastos_otros, utilidad, " +
                "fecha_inicio_obra, fecha_inicio_obra_max, con.fecha_entrega_terreno fecha_entrega_terreno, estado " +
                "FROM contratos con " +
                "JOIN proyectos pro ON pro.id = con.proyecto_id " +
                "JOIN contrato_usuarios cus ON con.id = cus.contrato_id " +
                "WHERE cus.usuario_id = " + id;
                SqlCommand comando = new SqlCommand(sql, cnn);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Contrato_proyectosModel objContratos = new Contrato_proyectosModel();
                    objContratos.proyecto_id = Convert.ToInt32(reader["proyecto_id"]);
                    objContratos.proyecto = reader["proyecto"].ToString();
                    objContratos.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                    objContratos.ruc = reader["ruc"].ToString();
                    objContratos.razon_social = reader["razon_social"].ToString();
                    objContratos.numero = reader["numero"].ToString();

                    objContratos.fecha = reader["fecha"].ToString();
                    objContratos.presupuesto_contratado = Decimal.Parse(reader["presupuesto_contratado"].ToString());
                    objContratos.presupuesto_referencial = Decimal.Parse(reader["presupuesto_referencial"].ToString());
                    objContratos.plazo = Decimal.Parse(reader["plazo"].ToString());

                    objContratos.adelanto_directo = Decimal.Parse(reader["adelanto_directo"].ToString());
                    objContratos.gastos_generales = Decimal.Parse(reader["gastos_generales"].ToString());
                    objContratos.gastos_otros = Decimal.Parse(reader["gastos_otros"].ToString());
                    objContratos.utilidad = Decimal.Parse(reader["utilidad"].ToString());
                    objContratos.fecha_inicio_obra = reader["fecha_inicio_obra"].ToString();
                    objContratos.fecha_inicio_obra_max = reader["fecha_inicio_obra_max"].ToString();
                    objContratos.fecha_entrega_terreno = reader["fecha_entrega_terreno"].ToString();
                    objContratos.porcentaje_ganador = Decimal.Parse(reader["porcentaje_ganador"].ToString());

                    objContratos.estado = Convert.ToInt32(reader["estado"]);
                    lista.Add(objContratos);
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
        public void Insert(ContratosModel objContratos)
        {
            Conectar();
            try
            {
                string sql = "insert into contratos (proyecto_id,	ruc, razon_social, numero, fecha, plazo, presupuesto_referencial, presupuesto_contratado,      adelanto_directo, gastos_generales, gastos_otros, utilidad, fecha_inicio_obra, fecha_inicio_obra_max, fecha_entrega_terreno, estado, porcentaje_ganador) VALUES " +
                                                               "(@proyecto_id, @ruc, @razon_social, @numero, @fecha, @plazo, @presupuesto_referencial, @presupuesto_contratado, @adelanto_directo, @gastos_generales, @gastos_otros, @utilidad, @fecha_inicio_obra, @fecha_inicio_obra_max, @fecha_entrega_terreno, @estado, @porcentaje_ganador)";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@proyecto_id", objContratos.proyecto_id);
                cmd.Parameters.AddWithValue("@ruc", objContratos.ruc);
                cmd.Parameters.AddWithValue("@razon_social", objContratos.razon_social);
                cmd.Parameters.AddWithValue("@numero", objContratos.numero);
                cmd.Parameters.AddWithValue("@fecha", objContratos.fecha);                
                cmd.Parameters.AddWithValue("@plazo", objContratos.plazo);
                cmd.Parameters.AddWithValue("@presupuesto_referencial", objContratos.presupuesto_referencial);
                cmd.Parameters.AddWithValue("@presupuesto_contratado", objContratos.presupuesto_contratado);

                cmd.Parameters.AddWithValue("@adelanto_directo", objContratos.adelanto_directo);
                cmd.Parameters.AddWithValue("@gastos_generales", objContratos.gastos_generales);
                cmd.Parameters.AddWithValue("@gastos_otros", objContratos.gastos_otros);
                cmd.Parameters.AddWithValue("@utilidad", objContratos.utilidad);
                cmd.Parameters.AddWithValue("@fecha_inicio_obra", objContratos.fecha_inicio_obra);
                cmd.Parameters.AddWithValue("@fecha_inicio_obra_max", objContratos.fecha_inicio_obra_max);
                cmd.Parameters.AddWithValue("@fecha_entrega_terreno", objContratos.fecha_entrega_terreno);
                cmd.Parameters.AddWithValue("@estado", objContratos.estado);
                cmd.Parameters.AddWithValue("@porcentaje_ganador", objContratos.porcentaje_ganador);
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
        public void update_datos_presupuesto(ContratosModel objContratos)
        {
            Conectar();
            try
            {
                string sql = "update contratos set presupuesto_notas = @presupuesto_notas where id = " + objContratos.id;
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@presupuesto_notas", objContratos.presupuesto_notas);
                cmd.Parameters.AddWithValue("@id", objContratos.id);
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
        public void Update(ContratosModel objContratos)
        {
            Conectar();
            try
            {
               // string fecha = "2021-09-17";
                /* string fecha = objContratos.fecha;
                string[] fechas = fecha.Split('/');
                fecha = fechas[2] + "/" + fechas[1] + "/" + fechas[0];

                string fecha_inicio_obra = objContratos.fecha_inicio_obra;
                string[] fechas2 = fecha_inicio_obra.Split('/');
                fecha_inicio_obra = fechas2[2] + "/" + fechas2[1] + "/" + fechas2[0];

                string fecha_inicio_obra_max = objContratos.fecha_inicio_obra_max;
                string[] fechas3 = fecha_inicio_obra_max.Split('/');
                fecha_inicio_obra_max = fechas3[2] + "/" + fechas3[1] + "/" + fechas3[0];

                string fecha_entrega_terreno = objContratos.fecha_entrega_terreno;
                string[] fechas4 = fecha_entrega_terreno.Split('/');
                fecha_entrega_terreno = fechas4[2] + "/" + fechas4[1] + "/" + fechas4[0];*/

                //string sql = "UPDATE contratos SET ruc = '" + objContratos.ruc + "', razon_social = '" + objContratos.razon_social + "', numero = '" + objContratos.numero + "', presupuesto_referencial = '" + objContratos.presupuesto_referencial + "', presupuesto_contratado = '" + objContratos.presupuesto_contratado + "', plazo = '" + objContratos.plazo + "', adelanto_directo = '" + objContratos.adelanto_directo + "', gastos_generales = '" + objContratos.gastos_generales + "', gastos_otros = '" + objContratos.gastos_otros + "', utilidad = '" + objContratos.utilidad + "', fecha = '" + fecha + "', fecha_inicio_obra = '" + fecha + "', fecha_inicio_obra_max = '" + fecha + "', fecha_entrega_terreno = '" + fecha + "', porcentaje_ganador = '" + objContratos.porcentaje_ganador + "' WHERE id = " + objContratos.id;
                string sql = "UPDATE contratos SET ruc = '" + objContratos.ruc;
                       sql += "', proyecto_id = " + objContratos.proyecto_id; 
                       sql += ", razon_social = '" + objContratos.razon_social;
                       sql += "', numero= '" + objContratos.numero;
                       sql += "', fecha = '" + objContratos.fecha;
                       sql += "', presupuesto_referencial = " + Convert.ToDecimal(objContratos.presupuesto_referencial).ToString("0.##");
                       sql += ", presupuesto_contratado = " + Convert.ToDecimal(objContratos.presupuesto_contratado).ToString("0.##");
                       sql += ", plazo = " + Convert.ToDecimal(objContratos.plazo).ToString("0.##");
                       sql += ", adelanto_directo = " + Convert.ToDecimal(objContratos.adelanto_directo).ToString("0.##");
                       sql += ", gastos_generales = " + Convert.ToDecimal(objContratos.gastos_generales).ToString("0.##");
                       sql += ", gastos_otros = " + Convert.ToDecimal(objContratos.gastos_otros).ToString("0.##");
                       sql += ", utilidad = " + Convert.ToDecimal(objContratos.utilidad).ToString("0.##");
                       sql += ", fecha_inicio_obra = '" + objContratos.fecha_inicio_obra;
                       sql += "' , fecha_inicio_obra_max = '" + objContratos.fecha_inicio_obra_max;
                       sql += "' , fecha_entrega_terreno = '" + objContratos.fecha_entrega_terreno;
                       sql += "', porcentaje_ganador = " + Convert.ToDecimal(objContratos.porcentaje_ganador).ToString("0.##");

                //sql += "', presupuesto_referencial = " +objContratos.presupuesto_referencial;
                sql +=" WHERE id = " + objContratos.id;
                SqlCommand cmd = new SqlCommand(sql, cnn);
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
        public ContratosModel ConsultarItem(int id)
        {
            Conectar();
            ContratosModel objContrato = new ContratosModel();
            try
            {
                string sql = "select *from contratos WHERE id = '" + id + "'";
                SqlCommand comando = new SqlCommand(sql, cnn);
                SqlDataReader reader = comando.ExecuteReader();                

                while (reader.Read())
                {
                    objContrato.id = Convert.ToInt32(reader["id"]);
                    objContrato.proyecto_id = Convert.ToInt32(reader["proyecto_id"]);
                    objContrato.ruc = reader["ruc"].ToString();
                    objContrato.razon_social = reader["razon_social"].ToString();
                    objContrato.numero = reader["numero"].ToString();
                    objContrato.fecha = reader["fecha"].ToString();
                    objContrato.numero = reader["numero"].ToString();                    
                    objContrato.plazo = Convert.ToInt32(reader["plazo"]);
                    objContrato.presupuesto_referencial = Decimal.Parse(reader["presupuesto_referencial"].ToString());
                    objContrato.presupuesto_contratado = Decimal.Parse(reader["presupuesto_contratado"].ToString());

                    objContrato.adelanto_directo = Decimal.Parse(reader["adelanto_directo"].ToString());
                    objContrato.gastos_generales = Decimal.Parse(reader["gastos_generales"].ToString());
                    objContrato.gastos_otros = Decimal.Parse(reader["gastos_otros"].ToString());
                    objContrato.utilidad = Decimal.Parse(reader["utilidad"].ToString());

                    objContrato.fecha_inicio_obra = reader["fecha_inicio_obra"].ToString();
                    objContrato.fecha_inicio_obra_max = reader["fecha_inicio_obra_max"].ToString();
                    objContrato.fecha_entrega_terreno = reader["fecha_entrega_terreno"].ToString();
                    objContrato.estado = Convert.ToInt32(reader["estado"]);
                    objContrato.presupuesto_guardado = Convert.ToInt32(reader["presupuesto_guardado"]);
                    objContrato.presupuesto_aceptado = Convert.ToInt32(reader["presupuesto_aceptado"]);
                    objContrato.porcentaje_ganador = Decimal.Parse(reader["porcentaje_ganador"].ToString());
                    objContrato.presupuesto_notas = reader["presupuesto_notas"].ToString();
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
            return objContrato;
        }
        public void Delete_update(int id)
        {
            Conectar();
            string sql = "UPDATE contratos SET estado =  0 WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}