using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class UsuariosAdmin : Conexion
    {

        public UsuariosModel LoginProcess(String correo, String password)
        {
            Conectar();
            UsuariosModel objUsuario = new UsuariosModel();
            try
            {
                string update = "SELECT *FROM usuarios WHERE correo = '" + correo + "' AND password = '" + password + "'";
                SqlCommand comando = new SqlCommand(update, cnn);

                SqlDataReader reader = comando.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objUsuario.id = Convert.ToInt32(reader["id"]);
                        objUsuario.usuario = reader["usuario"].ToString();
                        objUsuario.correo = reader["correo"].ToString();
                        objUsuario.numero_documento = reader["numero_documento"].ToString();
                        objUsuario.password = reader["password"].ToString();
                        objUsuario.tipo_usuario_id = Convert.ToInt32(reader["tipo_usuario_id"]);
                    }
                }
                else
                {
                    objUsuario.id = 0;
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
            return objUsuario;
        }        

    }    

}