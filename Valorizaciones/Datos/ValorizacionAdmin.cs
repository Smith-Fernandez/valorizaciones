using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class ValorizacionAdmin : Conexion
    {
        public IEnumerable<ValorizacionTrabajoModel> ConsultarAll(int contrato_id)
        {
            Conectar();
            List<ValorizacionTrabajoModel> lista = new List<ValorizacionTrabajoModel>();

            string sql = "select par.partida, cpa.codigo, cpa.cantidad cantidad, cpa.precio, ISNULL(val.cantidad, 0) AS cantidad_valorizado, par.id partida_id, " +
                "cpa.id contrato_partida_id, ISNULL(val.id, 0) AS valorizacion_id, ISNULL(pgr.id, 0) AS programacion_ejecucion_id " +
                "from contrato_partidas cpa " +
                "join partidas par on par.id = cpa.partida_id left " +
                "join valorizaciones val on val.contrato_partida_id = cpa.id " +
                "left join programacion_ejecuciones pgr on pgr.id = val.programacion_ejecucion_id " +
                "left join programaciones pro on pro.id = pgr.programacion_id AND pro.id = 1016 WHERE cpa.contrato_id = " + contrato_id + " ORDER BY cpa.codigo ";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {                
                ValorizacionTrabajoModel objValorizaciones = new ValorizacionTrabajoModel();
                objValorizaciones.partida = reader["partida"].ToString();
                objValorizaciones.codigo = reader["codigo"].ToString();
                objValorizaciones.cantidad = Decimal.Parse(reader["cantidad"].ToString());
                objValorizaciones.precio = Decimal.Parse(reader["precio"].ToString());
                objValorizaciones.cantidad_valorizado = Decimal.Parse(reader["cantidad_valorizado"].ToString());                
                objValorizaciones.partida_id = Convert.ToInt32(reader["partida_id"]);
                objValorizaciones.contrato_partida_id = Convert.ToInt32(reader["contrato_partida_id"]);
                objValorizaciones.valorizacion_id = Convert.ToInt32(reader["valorizacion_id"]);
                objValorizaciones.programacion_ejecucion_id = Convert.ToInt32(reader["programacion_ejecucion_id"]);
                lista.Add(objValorizaciones);
            }
            return lista;
        }
    }
}