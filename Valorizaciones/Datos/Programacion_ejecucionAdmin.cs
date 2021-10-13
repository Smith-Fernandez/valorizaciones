using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class Programacion_ejecucionAdmin : Conexion
    {
        public void Insert(Programacion_ejecucionesModel objProgramacion_ejecion)
        {
            Conectar();
            string sql = "insert into programacion_ejecuciones (programacion_id, ejecucion, amortizacion, fecha) values (@programacion_id, @ejecucion, @amortizacion, @fecha)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@programacion_id", objProgramacion_ejecion.programacion_id);
            cmd.Parameters.AddWithValue("@ejecucion", objProgramacion_ejecion.ejecucion);
            cmd.Parameters.AddWithValue("@amortizacion", objProgramacion_ejecion.amortizacion);
            cmd.Parameters.AddWithValue("@fecha", objProgramacion_ejecion.fecha);
            cmd.ExecuteNonQuery();
        }

    }
}