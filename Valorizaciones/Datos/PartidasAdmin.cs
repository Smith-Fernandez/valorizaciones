using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class PartidasAdmin : Conexion
    {
        public IEnumerable<Partida_unidadesModel> ConsultarAll()
        {
            Conectar();            
            List<Partida_unidadesModel> lista = new List<Partida_unidadesModel>();

            string sql = "select par.id partida_id, partida,	unidad_id,	eliminado,	uni.id unidad_id, unidad from partidas par join unidades uni on par.unidad_id = uni.id WHERE par.eliminado = 0 ORDER BY par.id DESC";
            SqlCommand comando = new SqlCommand(sql, cnn);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Partida_unidadesModel objPartidas = new Partida_unidadesModel();
                objPartidas.partida_id = Convert.ToInt32(reader["partida_id"]);
                objPartidas.partida = reader["partida"].ToString();
                objPartidas.unidad_id = Convert.ToInt32(reader["unidad_id"]);
                objPartidas.unidad = reader["unidad"].ToString();
                objPartidas.eliminado = Convert.ToInt32(reader["eliminado"]);
                lista.Add(objPartidas);
            }
            return lista;
        }

        public IEnumerable<Partida_unidadesModel> ConsultarByPartida(string partida_id)
        {
            Conectar();
            List<Partida_unidadesModel> lista = new List<Partida_unidadesModel>();
            string sql = "select par.id partida_id, partida,	unidad_id,	eliminado,	uni.id unidad_id, unidad from partidas par join unidades uni on par.unidad_id = uni.id WHERE par.eliminado = 0  AND par.id = '" + partida_id + "' ORDER BY par.id DESC";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Partida_unidadesModel objPartidas = new Partida_unidadesModel();
                objPartidas.partida_id = Convert.ToInt32(reader["partida_id"]);
                objPartidas.partida = reader["partida"].ToString();
                objPartidas.unidad_id = Convert.ToInt32(reader["unidad_id"]);
                objPartidas.unidad = reader["unidad"].ToString();
                objPartidas.eliminado = Convert.ToInt32(reader["eliminado"]);
                lista.Add(objPartidas);
            }
            return lista;
        }

        public IEnumerable<PartidasModel> ConsultarBuscador(string parametro)
        {
            Conectar();
            List<PartidasModel> lista = new List<PartidasModel>();

            string sql = "SELECT *FROM partidas where partida like  '%" + parametro  + "%';";

            SqlCommand comando = new SqlCommand(sql, cnn);

            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                PartidasModel objPartidas = new PartidasModel();

                objPartidas.id = Convert.ToInt32(reader["id"]);
                objPartidas.partida = reader["partida"].ToString();
                objPartidas.value = reader["partida"].ToString();
                objPartidas.unidad_id = Convert.ToInt32(reader["unidad_id"]);
                objPartidas.eliminado = Convert.ToInt32(reader["eliminado"]);

                lista.Add(objPartidas);
            }
            return lista;
        }        

        public Partida_unidadesModel ConsultarItem(int id)
        {
            Conectar();

            Partida_unidadesModel objPartida = new Partida_unidadesModel();
            try
            {
                string sql = "select par.id partida_id, par.partida,	par.unidad_id,	par.eliminado,	uni.id unidad_id, uni.unidad from partidas par join unidades uni on par.unidad_id = uni.id where par.id = '" + id + "'";
                SqlCommand comando = new SqlCommand(sql, cnn);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    objPartida.partida_id = Convert.ToInt32(reader["partida_id"]);
                    objPartida.partida = reader["partida"].ToString();
                    objPartida.unidad = reader["unidad"].ToString();
                    objPartida.unidad_id = Convert.ToInt32(reader["unidad_id"]);
                    objPartida.eliminado = Convert.ToInt32(reader["eliminado"]);
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
            return objPartida;
        }

        public void Insert(PartidasModel objPartidas)
        {
            Conectar();
            string sql = "insert into partidas (partida, unidad_id, eliminado) values (@partida, @unidad_id, 0);";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@partida", objPartidas.partida);
            cmd.Parameters.AddWithValue("@unidad_id", objPartidas.unidad_id);
            cmd.ExecuteNonQuery();
        }

        public void Update(Partida_unidadesModel objPartidas)
        {
            Conectar();
            string sql = "update partidas set partida = @partida, unidad_id = @unidad_id where id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@partida", objPartidas.partida);
            cmd.Parameters.AddWithValue("@unidad_id", objPartidas.unidad_id);
            cmd.Parameters.AddWithValue("@id", objPartidas.partida_id);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            Conectar();
            string sql = "delete from partidas where id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
        
        public void Delete_update(int id)
        {
            Conectar();
            string sql = "UPDATE partidas SET eliminado =  1 WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }        

    }
}