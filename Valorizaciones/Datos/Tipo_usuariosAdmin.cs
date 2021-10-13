using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class Tipo_usuariosAdmin : Conexion
    {
        public IEnumerable<Tipo_usuariosModel> ConsultarAll()
        {
            Conectar();
            List<Tipo_usuariosModel> lista = new List<Tipo_usuariosModel>();

            string sql = "SELECT * FROM tipo_usuarios";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Tipo_usuariosModel objTipo_usuarios = new Tipo_usuariosModel();
                objTipo_usuarios.id = Convert.ToInt32(reader["id"]);
                objTipo_usuarios.tipo_usuario = reader["tipo_usuario"].ToString();
                lista.Add(objTipo_usuarios);
            }
            return lista;
        }

    }
}