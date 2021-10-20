using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    //HOLA CAMBIO22021
    public class ActividadesAdmin : Conexion
    { 
        public IEnumerable<ActividadesModel> ConsultarAll()
        {
            Conectar();
            List<ActividadesModel> lista = new List<ActividadesModel>();

            string sql = "SELECT * FROM actividades";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {                
                ActividadesModel objActividades = new ActividadesModel();
                objActividades.id = Convert.ToInt32(reader["id"]);
                objActividades.actividad = reader["actividad"].ToString();
                objActividades.abreviatura = reader["abreviatura"].ToString();
                objActividades.eliminado = Convert.ToInt32(reader["eliminado"]);
                lista.Add(objActividades);
            }
            return lista;
        }
    }
}