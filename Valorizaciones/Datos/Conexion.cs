﻿using System;
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
                cnn = new SqlConnection("Data Source=(local);Integrated security=SSPI; Initial Catalog=valorizaciones;");
               // cnn = new SqlConnection("Data Source=(local);User Id =sa;Password=1nf0rm@t1c@ ;Initial Catalog=valorizaciones;");
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