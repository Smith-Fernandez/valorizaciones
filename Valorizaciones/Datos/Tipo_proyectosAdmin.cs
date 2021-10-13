using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class Tipo_proyectosAdmin:Conexion
    {        

        public IEnumerable<Tipo_proyectosModel> ConsultarAll()
        {
            Conectar();
            List<Tipo_proyectosModel> lista = new List<Tipo_proyectosModel>();

            string sql = "SELECT * FROM tipo_proyectos";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Tipo_proyectosModel objTipo_proyectos = new Tipo_proyectosModel();                
                objTipo_proyectos.id = Convert.ToInt32(reader["id"]);
                objTipo_proyectos.tipo_proyecto = reader["tipo_proyecto"].ToString();
                objTipo_proyectos.eliminado = Convert.ToInt32(reader["eliminado"]);
                lista.Add(objTipo_proyectos);
            }
            return lista;
        }
    }
}