using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class Contrato_partidasAdmin : Conexion
    {
        public IEnumerable<Contrato_partidasModel> ConsultarAll()
        {
            Conectar();
            List<Contrato_partidasModel> lista = new List<Contrato_partidasModel>();

            string sql = "SELECT * FROM contrato_partidas";
            SqlCommand comando = new SqlCommand(sql, cnn);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Contrato_partidasModel objContrato_partidas = new Contrato_partidasModel();

                objContrato_partidas.id = Convert.ToInt32(reader["id"]);
                objContrato_partidas.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                objContrato_partidas.partida_id = Convert.ToInt32(reader["partida_id"]);
                objContrato_partidas.codigo = reader["codigo"].ToString();
                objContrato_partidas.cantidad = Decimal.Parse(reader["cantidad"].ToString());
                objContrato_partidas.precio = Decimal.Parse(reader["precio"].ToString());
                objContrato_partidas.aprobancion_contratista = Convert.ToInt32(reader["aprobancion_contratista"]);

                lista.Add(objContrato_partidas);
            }
            return lista;
        }

        public IEnumerable<Contrato_partidasModel> ConsultarByContrato(int contrato_id)
        {
            Conectar();
            List<Contrato_partidasModel> lista = new List<Contrato_partidasModel>();
            string sql = "select* from partidas par JOIN contrato_partidas cpa ON par.id = cpa.partida_id WHERE par.eliminado = 0 AND cpa.contrato_id = '"+ contrato_id + "'";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Contrato_partidasModel objContrato_partidas = new Contrato_partidasModel();
                objContrato_partidas.id = Convert.ToInt32(reader["id"]);
                objContrato_partidas.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                objContrato_partidas.partida_id = Convert.ToInt32(reader["partida_id"]);
                objContrato_partidas.partida = reader["partida"].ToString();
                objContrato_partidas.codigo = reader["codigo"].ToString();
                objContrato_partidas.cantidad = Decimal.Parse(reader["cantidad"].ToString());
                objContrato_partidas.precio = Decimal.Parse(reader["precio"].ToString());
                objContrato_partidas.aprobancion_contratista = Convert.ToInt32(reader["aprobancion_contratista"]);
                lista.Add(objContrato_partidas);
            }
            return lista;
        }        

        public IEnumerable<Contrato_partidasModel> ConsultarAllByContrato(int contrato_id)
        {
            Conectar();
            List<Contrato_partidasModel> lista = new List<Contrato_partidasModel>();
            string sql = "SELECT cpa.id id, * FROM partidas par JOIN contrato_partidas cpa ON par.id = cpa.partida_id WHERE par.eliminado = 0 AND contrato_id = '" + contrato_id + "' ORDER BY codigo";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Contrato_partidasModel objContrato_partidas = new Contrato_partidasModel();
                objContrato_partidas.id = Convert.ToInt32(reader["id"]);
                objContrato_partidas.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                objContrato_partidas.partida_id = Convert.ToInt32(reader["partida_id"]);
                objContrato_partidas.partida = reader["partida"].ToString();
                objContrato_partidas.codigo = reader["codigo"].ToString();
                objContrato_partidas.cantidad = Decimal.Parse(reader["cantidad"].ToString());
                objContrato_partidas.precio = Decimal.Parse(reader["precio"].ToString());
                objContrato_partidas.aprobancion_contratista = Convert.ToInt32(reader["aprobancion_contratista"]);
                lista.Add(objContrato_partidas);
            }
            return lista;
        }

        public Contrato_partidasModel ConsultarItem(int id)
        {
            Conectar();

            Contrato_partidasModel objContrato_partidas = new Contrato_partidasModel();
            try
            {
                string sql = "SELECT *FROM contrato_partidas where id = '" + id + "'";
                SqlCommand comando = new SqlCommand(sql, cnn);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    objContrato_partidas.id = Convert.ToInt32(reader["id"]);
                    objContrato_partidas.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                    objContrato_partidas.partida_id = Convert.ToInt32(reader["partida_id"]);
                    objContrato_partidas.codigo = reader["codigo"].ToString();
                    objContrato_partidas.cantidad = Decimal.Parse(reader["cantidad"].ToString());
                    objContrato_partidas.precio = Decimal.Parse(reader["precio"].ToString());
                    objContrato_partidas.aprobancion_contratista = Convert.ToInt32(reader["aprobancion_contratista"]);
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
            return objContrato_partidas;
        }

        public void Insert(Contrato_partidasModel objContrato_partidas)
        {
            Conectar();
            string sql = "insert into contrato_partidas (contrato_id,	partida_id,	codigo,	cantidad, precio, aprobancion_contratista) values (@contrato_id, @partida_id, @codigo, @cantidad, @precio, @aprobancion_contratista)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@contrato_id", objContrato_partidas.contrato_id);
            cmd.Parameters.AddWithValue("@partida_id", objContrato_partidas.partida_id);
            cmd.Parameters.AddWithValue("@codigo", objContrato_partidas.codigo);
            cmd.Parameters.AddWithValue("@cantidad", objContrato_partidas.cantidad);
            cmd.Parameters.AddWithValue("@precio", objContrato_partidas.precio);
            cmd.Parameters.AddWithValue("@aprobancion_contratista", objContrato_partidas.aprobancion_contratista);
            cmd.ExecuteNonQuery();
        }

        public void Update(Contrato_partidasModel objContrato_partidas)
        {
            Conectar();
            string sql = "update contrato_partidas set contrato_id = @contrato_id, partida_id = @partida_id, codigo = @codigo, cantidad = @cantidad, precio = @precio, aprobancion_contratista = @aprobancion_contratista WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@contrato_id", objContrato_partidas.contrato_id);
            cmd.Parameters.AddWithValue("@partida_id", objContrato_partidas.partida_id);
            cmd.Parameters.AddWithValue("@codigo", objContrato_partidas.codigo);
            cmd.Parameters.AddWithValue("@cantidad", objContrato_partidas.cantidad);
            cmd.Parameters.AddWithValue("@precio", objContrato_partidas.precio);
            cmd.Parameters.AddWithValue("@aprobancion_contratista", objContrato_partidas.aprobancion_contratista);
            cmd.Parameters.AddWithValue("@id", objContrato_partidas.id);
            cmd.ExecuteNonQuery();
        }

        public void updatePartida_aprobacion(Contrato_partidasModel objContrato_partidas)
        {
            Conectar();
            string sql = "update contrato_partidas set aprobancion_contratista = @aprobancion_contratista WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;            
            cmd.Parameters.AddWithValue("@aprobancion_contratista", objContrato_partidas.aprobancion_contratista);
            cmd.Parameters.AddWithValue("@id", objContrato_partidas.id);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            Conectar();
            string sql = "delete from contrato_partidas where id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}