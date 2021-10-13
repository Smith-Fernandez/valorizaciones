using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class PersonaAdmin:Conexion
    {
        public IEnumerable<PersonaModel> Consultar()
        {
            Conectar();
            List<PersonaModel> lista = new List<PersonaModel>();
            try
            {
                SqlCommand comando = new SqlCommand("sp_consultar", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    PersonaModel modelo = new PersonaModel()
                    {
                        Id = int.Parse(lector[0].ToString()),
                        Nombre = lector[1] + "",
                        Apellido = lector[2] + "",
                        Edad = int.Parse(lector[3] + ""),
                        fecha_nacimiento = lector[4] + "",
                        sueldo = decimal.Parse(lector[5] + "")
                    };
                    lista.Add(modelo);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Desconectar();
            }
            return lista;
        }

        public void Guardar(PersonaModel modelo)
        {
            Conectar();
            try
            {
                SqlCommand comando = new SqlCommand("sp_guardar", cnn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombre", modelo.Nombre);
                comando.Parameters.AddWithValue("@apellido", modelo.Apellido);
                comando.Parameters.AddWithValue("@edad", modelo.Edad);
                comando.Parameters.AddWithValue("@fecha_nacimiento", modelo.fecha_nacimiento);
                comando.Parameters.AddWithValue("@sueldo", modelo.sueldo);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            finally
            {

            }
        }
    }
}