using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class UnidadesAdmin:Conexion
    {
        public IEnumerable<UnidadesModel> ConsultarAll()
        {
            Conectar();
            List<UnidadesModel> lista = new List<UnidadesModel>();

            string sql = "SELECT * FROM unidades WHERE activo = 1";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                UnidadesModel objUnidades = new UnidadesModel();
                objUnidades.id = Convert.ToInt32(reader["id"]);
                objUnidades.codigo = reader["codigo"].ToString();
                objUnidades.unidad = reader["unidad"].ToString();
                objUnidades.activo = Convert.ToInt32(reader["activo"]);
                lista.Add(objUnidades);
            }
            return lista;
        }

        public IEnumerable<UnidadesModel> ConsultarBuscador(string parametro)
        {
            Conectar();
            List<UnidadesModel> lista = new List<UnidadesModel>();

            string sql = "SELECT *FROM unidades where WHERE activo = 1 AND unidad like  '%" + parametro + "%';";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                UnidadesModel objUnidad = new UnidadesModel();
                objUnidad.id = Convert.ToInt32(reader["id"]);
                objUnidad.unidad = reader["unidad"].ToString();
                objUnidad.codigo = reader["codigo"].ToString();
                objUnidad.activo = Convert.ToInt32(reader["activo"]);
                lista.Add(objUnidad);
            }
            return lista;
        }
    }
}