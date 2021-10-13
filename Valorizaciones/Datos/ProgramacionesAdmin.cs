using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class ProgramacionesAdmin:Conexion
    {
        public IEnumerable<ProgramacionesModel> ConsultarAll()
        {
            Conectar();
            List<ProgramacionesModel> lista = new List<ProgramacionesModel>();

            string sql = "SELECT * FROM programaciones";
            SqlCommand comando = new SqlCommand(sql, cnn);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                ProgramacionesModel objProgramaciones = new ProgramacionesModel();
                
                objProgramaciones.id = Convert.ToInt32(reader["id"]);
                objProgramaciones.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                objProgramaciones.fecha = reader["fecha"].ToString();
                objProgramaciones.porcentaje = Decimal.Parse(reader["porcentaje"].ToString());

                lista.Add(objProgramaciones);
            }
            return lista;
        }

        public IEnumerable<Programaciones_reportModel> report_programaciones(int id)
        {
            Conectar();
            List<Programaciones_reportModel> lista = new List<Programaciones_reportModel>();

            string sql = "SELECT ISNULL(prg.contratista_id, 0) AS contratista_id , ISNULL(prg.supervisor_id, 0) AS supervisor_id, ISNULL(con.presupuesto_contratado, 0) AS presupuesto_contratado, con.id contrato_id, pro.id programacion_id, pro.fecha, pro.porcentaje, ISNULL(prg.id, 0) AS programacion_ejecucion_id, ISNULL(total_real, 0) AS total_real " +
                "FROM contratos con " +
                "INNER JOIN programaciones pro ON con.id = pro.contrato_id " +
                "LEFT JOIN programacion_ejecuciones prg ON pro.id = prg.programacion_id " +
                "LEFT JOIN (SELECT val.programacion_ejecucion_id programacion_ejecucion_id, SUM(cpa.precio * val.cantidad) total_real " +
                "FROM contrato_partidas cpa JOIN valorizaciones val ON cpa.id = val.contrato_partida_id WHERE cpa.contrato_id = " + id + " GROUP BY val.programacion_ejecucion_id) tabla_suma ON prg.id = tabla_suma.programacion_ejecucion_id " +
                "WHERE pro.contrato_id = " + id;
            SqlCommand comando = new SqlCommand(sql, cnn);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Programaciones_reportModel objProgramaciones = new Programaciones_reportModel();

                objProgramaciones.contratista_id            = Convert.ToInt32(reader["contratista_id"]);
                objProgramaciones.supervisor_id             = Convert.ToInt32(reader["supervisor_id"]);
                objProgramaciones.presupuesto_contratado    = Decimal.Parse(reader["presupuesto_contratado"].ToString());
                objProgramaciones.contrato_id               = Convert.ToInt32(reader["contrato_id"]);
                objProgramaciones.programacion_id           = Convert.ToInt32(reader["programacion_id"]);
                objProgramaciones.fecha                     = reader["fecha"].ToString();
                objProgramaciones.porcentaje                = Decimal.Parse(reader["porcentaje"].ToString());
                objProgramaciones.programacion_ejecucion_id = Convert.ToInt32(reader["programacion_ejecucion_id"]);
                objProgramaciones.total_real                = Decimal.Parse(reader["total_real"].ToString());
                lista.Add(objProgramaciones);
            }
            return lista;
        }
        
        public ProgramacionesModel ConsultarItem(int id)
        {
            Conectar();

            ProgramacionesModel objProgramaciones = new ProgramacionesModel();
            try
            {
                string update = "SELECT *FROM programaciones where id = '" + id + "'";
                SqlCommand comando = new SqlCommand(update, cnn);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    objProgramaciones.id = Convert.ToInt32(reader["id"]);
                    objProgramaciones.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                    objProgramaciones.fecha = reader["fecha"].ToString();
                    objProgramaciones.porcentaje = Decimal.Parse(reader["porcentaje"].ToString());
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
            return objProgramaciones;
        }

        public ProgramacionesModel filasProgramacionesEjecucion(int id)
        {
            Conectar();

            ProgramacionesModel objProgramaciones = new ProgramacionesModel();
            try
            {
                string update = "SELECT count(pro.id) as filas FROM programaciones pro " +
                    "JOIN programacion_ejecuciones pgr on pro.id = pgr.programacion_id " +
                    "WHERE contrato_id = " + id;
                SqlCommand comando = new SqlCommand(update, cnn);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    objProgramaciones.id = Convert.ToInt32(reader["filas"]);
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
            return objProgramaciones;
        }

        public IEnumerable<ContratoProgramacionModel> MontoContatoConProgramacion(int id)
        {
            Conectar();
            List<ContratoProgramacionModel> lista = new List<ContratoProgramacionModel>();
            string update = "SELECT pro.id, pro.porcentaje, pro.fecha, con.presupuesto_contratado, con.presupuesto_referencial, pro.porcentaje " +
                "FROM programaciones pro " +
                "JOIN contratos con ON con.id = pro.contrato_id " +
                "WHERE con.id = " + id + " ORDER BY pro.fecha";
            SqlCommand comando = new SqlCommand(update, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                ContratoProgramacionModel objProgramaciones = new ContratoProgramacionModel();
                objProgramaciones.id = Convert.ToInt32(reader["id"]);
                objProgramaciones.fecha = reader["fecha"].ToString();
                objProgramaciones.porcentaje = Decimal.Parse(reader["porcentaje"].ToString());
                objProgramaciones.presupuesto_contratado = Decimal.Parse(reader["presupuesto_contratado"].ToString());
                objProgramaciones.presupuesto_referencial = Decimal.Parse(reader["presupuesto_referencial"].ToString());                
                lista.Add(objProgramaciones);
            }
            return lista;
        }

        public IEnumerable<ProgramacionesModel> ConsultarAllByContrato(int contrato_id)
        {
            Conectar();
            List<ProgramacionesModel> lista = new List<ProgramacionesModel>();
            string sql = "SELECT * FROM programaciones WHERE eliminado = 0 AND contrato_id = '" + contrato_id + "' ORDER BY id";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                ProgramacionesModel objProgramaciones = new ProgramacionesModel();
                objProgramaciones.id = Convert.ToInt32(reader["id"]);
                objProgramaciones.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                objProgramaciones.fecha = reader["fecha"].ToString();
                objProgramaciones.porcentaje = Convert.ToInt32(reader["porcentaje"]);
                lista.Add(objProgramaciones);
            }
            return lista;
        }

        public void Insert(ProgramacionesModel objProgramaciones)
        {
            Conectar();
            string sql = "insert into programaciones (contrato_id, fecha, porcentaje, eliminado) VALUES (@contrato_id, @fecha, @porcentaje, 0);";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@contrato_id", objProgramaciones.contrato_id);
            cmd.Parameters.AddWithValue("@fecha", objProgramaciones.fecha);
            cmd.Parameters.AddWithValue("@porcentaje", objProgramaciones.porcentaje);
            cmd.ExecuteNonQuery();
        }

        public void Update(ProgramacionesModel objProgramaciones)
        {
            Conectar();
            string sql = "update programaciones set contrato_id = @contrato_id, fecha = @fecha, porcentaje = @porcentaje where id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@contrato_id", objProgramaciones.contrato_id);
            string fecha = objProgramaciones.fecha;
            string[] fechas = fecha.Split('/');

            cmd.Parameters.AddWithValue("@fecha", fechas[2] + "/" + fechas[1] + "/" + fechas[0]);
            cmd.Parameters.AddWithValue("@porcentaje", objProgramaciones.porcentaje);
            cmd.Parameters.AddWithValue("@id", objProgramaciones.id);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            Conectar();
            string sql = "delete from programaciones where id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}