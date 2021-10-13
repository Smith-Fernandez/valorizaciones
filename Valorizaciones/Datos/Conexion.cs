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
                //cnn = new SqlConnection(@"Data Source=DESKTOP-FR904MP\SQLEXPRESS;Integrated security=True; Initial Catalog=valorizaciones;");
                //conexion servidor 
                // cnn = new SqlConnection("Data Source=(local);User Id =sa;Password=1nf0rm@t1c@ ;Initial Catalog=valorizaciones;");
                 cnn = new SqlConnection(@"Data Source=DESKTOP-SV0VCFQ\SQLEXPRESS;Integrated Security=True;Initial Catalog=valorizaciones;");
                 cnn.Open();
            }
            catch (Exception e)
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