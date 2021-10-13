using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class PaquetesAdmin : Conexion
    {
        public IEnumerable<PaquetesModel> ConsultarAll()
        {
            Conectar();
            List<PaquetesModel> lista = new List<PaquetesModel>();

            string sql = "SELECT * FROM paquetes";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                PaquetesModel objPaquetes = new PaquetesModel();                
                objPaquetes.id = Convert.ToInt32(reader["id"]);
                objPaquetes.paquete = reader["paquete"].ToString();
                objPaquetes.abreviatura = reader["abreviatura"].ToString();
                objPaquetes.eliminado = Convert.ToInt32(reader["eliminado"]);
                lista.Add(objPaquetes);
            }
            return lista;
        }
    }
}