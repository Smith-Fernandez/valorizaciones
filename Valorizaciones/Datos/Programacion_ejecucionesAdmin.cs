using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class Programacion_ejecucionesAdmin : Conexion
    {
        public void Insert(Programacion_ejecucionesModel objProgramacion_ejecion)
        {
            Conectar();
            string sql = "insert into programacion_ejecuciones (programacion_id, amortizacion, fecha, contratista_id, supervisor_id, valorizacion_supervisor_id) values (@programacion_id, @amortizacion, @fecha, @contratista_id, @supervisor_id, @valorizacion_supervisor_id)";

            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@programacion_id", objProgramacion_ejecion.programacion_id);
            cmd.Parameters.AddWithValue("@amortizacion", objProgramacion_ejecion.amortizacion);
            cmd.Parameters.AddWithValue("@fecha", objProgramacion_ejecion.fecha);
            cmd.Parameters.AddWithValue("@contratista_id", objProgramacion_ejecion.contratista_id);
            cmd.Parameters.AddWithValue("@supervisor_id", objProgramacion_ejecion.supervisor_id);
            cmd.Parameters.AddWithValue("@valorizacion_supervisor_id", objProgramacion_ejecion.valorizacion_supervisor_id);            

            cmd.ExecuteNonQuery();
        }

        public void Update(Programacion_ejecucionesModel objProgramacion_ejecion)
        {
            Conectar();
            string sql = "UPDATE programacion_ejecuciones SET " +
                " contratista_id = " + objProgramacion_ejecion.contratista_id + 
                ", supervisor_id = "+ objProgramacion_ejecion .supervisor_id +
                ", valorizacion_supervisor_id = " + objProgramacion_ejecion.valorizacion_supervisor_id +
                ", amortizacion = " + objProgramacion_ejecion.amortizacion +
                " WHERE id = " + objProgramacion_ejecion.id;
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        public void Update_supervisor(Programacion_ejecucionesModel objProgramacion_ejecion)
        {
            Conectar();
            string sql = "UPDATE programacion_ejecuciones SET " +
                " supervisor_id = " + objProgramacion_ejecion.supervisor_id +
                " WHERE id = " + objProgramacion_ejecion.id;
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        public void Update_supervisor_difiere(Programacion_ejecucionesModel objProgramacion_ejecion)
        {
            Conectar();
            string sql = "UPDATE programacion_ejecuciones SET " +
                " valorizacion_supervisor_id = " + objProgramacion_ejecion.valorizacion_supervisor_id +
                " WHERE id = " + objProgramacion_ejecion.id;
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }




        public int ConsultarByProgramacion(string programacion_id)
        {
            Conectar();
            Programacion_ejecucionesModel objProgramacion_ejecuciones = new Programacion_ejecucionesModel();
            objProgramacion_ejecuciones.id = 0;
            string sql = "select id from programacion_ejecuciones WHERE programacion_id = " + programacion_id;
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                objProgramacion_ejecuciones.id = Convert.ToInt32(reader["id"]);
            }

            int programacion_ejecuciones_id = objProgramacion_ejecuciones.id;
            return programacion_ejecuciones_id;
        }

        public int MaximoId()
        {
            Conectar();
            Programacion_ejecucionesModel objProgramacion_ejecuciones = new Programacion_ejecucionesModel();
            objProgramacion_ejecuciones.id = 0;
            string sql = "select max(id) id FROM programacion_ejecuciones";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                objProgramacion_ejecuciones.id = Convert.ToInt32(reader["id"]);
            }

            int programacion_ejecuciones_id = objProgramacion_ejecuciones.id;
            return programacion_ejecuciones_id;
        }


    }
}