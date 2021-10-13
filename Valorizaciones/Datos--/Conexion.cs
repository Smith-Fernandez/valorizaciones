using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Valorizaciones.Datos
{
    public class Conexion
    {
        protected SqlConnection cnn;

        protected void Conectar()
        {
            try
            {
                cnn = new  SqlConnection("Data Source=(local);Integrated security=SSPI; Initial Catalog=valorizaciones;");
                cnn.Open();
            }
            catch(Exception e)
            {

            }
        }

        protected void Desconectar()
        {
            try
            {
                cnn.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}