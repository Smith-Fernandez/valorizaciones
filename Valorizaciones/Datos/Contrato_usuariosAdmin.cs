using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class Contrato_usuariosAdmin : Conexion
    {
        public IEnumerable<Contrato_usuariosModel> ConsultarAll()
        {
            Conectar();
            List<Contrato_usuariosModel> lista = new List<Contrato_usuariosModel>();
            string sql = "select cus.id contrato_usuario_id, usu.id usuario_id, cus.contrato_id contrato_id, usuario, correo, numero_documento, tipo_usuario, password from usuarios usu join tipo_usuarios tus on tus.id = usu.tipo_usuario_id join contrato_usuarios cus on usu.id = cus.usuario_id ";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Contrato_usuariosModel objContrato_usuarios = new Contrato_usuariosModel();
                objContrato_usuarios.contrato_usuario_id = Convert.ToInt32(reader["contrato_usuario_id"]);
                objContrato_usuarios.usuario_id = Convert.ToInt32(reader["usuario_id"]);
                objContrato_usuarios.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                objContrato_usuarios.usuario = reader["usuario"].ToString();
                objContrato_usuarios.correo = reader["correo"].ToString();
                objContrato_usuarios.numero_documento = reader["numero_documento"].ToString();
                objContrato_usuarios.tipo_usuario = reader["tipo_usuario"].ToString();
                objContrato_usuarios.password = reader["password"].ToString();
                lista.Add(objContrato_usuarios);
            }
            return lista;
        }

        public IEnumerable<Contrato_usuariosModel> ConsultarByContrato(int contrato_id)
        {
            Conectar();
            List<Contrato_usuariosModel> lista = new List<Contrato_usuariosModel>();
            string sql = "select cus.id contrato_usuario_id, usu.id usuario_id, cus.contrato_id contrato_id, usuario, correo, numero_documento, tipo_usuario, password from usuarios usu join tipo_usuarios tus on tus.id = usu.tipo_usuario_id join contrato_usuarios cus on usu.id = cus.usuario_id WHERE usu.eliminado = 0 AND cus.contrato_id = '" + contrato_id + "'";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Contrato_usuariosModel objContrato_usuarios = new Contrato_usuariosModel();

                objContrato_usuarios.contrato_usuario_id = Convert.ToInt32(reader["contrato_usuario_id"]);
                objContrato_usuarios.usuario_id = Convert.ToInt32(reader["usuario_id"]);
                objContrato_usuarios.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                objContrato_usuarios.usuario = reader["usuario"].ToString();
                objContrato_usuarios.correo = reader["correo"].ToString();
                objContrato_usuarios.numero_documento = reader["numero_documento"].ToString();
                objContrato_usuarios.tipo_usuario = reader["tipo_usuario"].ToString();
                objContrato_usuarios.password = reader["password"].ToString();

                lista.Add(objContrato_usuarios);
            }
            return lista;
        }

        public IEnumerable<Contrato_usuariosModel> ConsultarAllByContrato(int contrato_id)
        {
            Conectar();
            List<Contrato_usuariosModel> lista = new List<Contrato_usuariosModel>();
            string sql = "select cus.id contrato_usuario_id, usu.id usuario_id, cus.contrato_id contrato_id, usuario, correo, numero_documento, tipo_usuario, password from usuarios usu join tipo_usuarios tus on tus.id = usu.tipo_usuario_id join contrato_usuarios cus on usu.id = cus.usuario_id WHERE usu.eliminado = 0 AND cus.contrato_id = '" + contrato_id + "' ORDER BY tus.id";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Contrato_usuariosModel objContrato_usuarios = new Contrato_usuariosModel();
                objContrato_usuarios.contrato_usuario_id = Convert.ToInt32(reader["contrato_usuario_id"]);
                objContrato_usuarios.usuario_id = Convert.ToInt32(reader["usuario_id"]);
                objContrato_usuarios.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                objContrato_usuarios.usuario = reader["usuario"].ToString();
                objContrato_usuarios.correo = reader["correo"].ToString();
                objContrato_usuarios.numero_documento = reader["numero_documento"].ToString();
                objContrato_usuarios.tipo_usuario = reader["tipo_usuario"].ToString();
                objContrato_usuarios.password = reader["password"].ToString();
                lista.Add(objContrato_usuarios);
            }
            return lista;
        }

        public Contrato_usuariosModel ConsultarItem(int id)
        {
            Conectar();

            Contrato_usuariosModel objContrato_usuarios = new Contrato_usuariosModel();
            try
            {
                string sql = "select cus.id contrato_usuario_id, usu.id usuario_id, cus.contrato_id contrato_id, usuario, correo, numero_documento, tipo_usuario, password from usuarios usu join tipo_usuarios tus on tus.id = usu.tipo_usuario_id join contrato_usuarios cus on usu.id = cus.usuario_id WHERE usu.eliminado = 0 AND cus.id = '" + id + "' ORDER BY tus.id";
                SqlCommand comando = new SqlCommand(sql, cnn);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    objContrato_usuarios.contrato_usuario_id = Convert.ToInt32(reader["contrato_usuario_id"]);
                    objContrato_usuarios.usuario_id = Convert.ToInt32(reader["usuario_id"]);
                    objContrato_usuarios.contrato_id = Convert.ToInt32(reader["contrato_id"]);
                    objContrato_usuarios.usuario = reader["usuario"].ToString();
                    objContrato_usuarios.correo = reader["correo"].ToString();
                    objContrato_usuarios.numero_documento = reader["numero_documento"].ToString();
                    objContrato_usuarios.tipo_usuario = reader["tipo_usuario"].ToString();
                    objContrato_usuarios.password = reader["password"].ToString();
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
            return objContrato_usuarios;
        }

        public void Insert(Contrato_usuariosModel objContrato_usuarios)
        {
            Conectar();            
            string sql = "insert into contrato_usuarios (contrato_id, usuario_id) values (@contrato_id, @usuario_id)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@contrato_id", objContrato_usuarios.contrato_id);
            cmd.Parameters.AddWithValue("@usuario_id", objContrato_usuarios.usuario_id);            
            cmd.ExecuteNonQuery();
        }

        public void Update(Contrato_usuariosModel objContrato_usuarios)
        {
            Conectar();
            string sql = "update contrato_usuarios set usuario_id = @usuario_id WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@usuario_id", objContrato_usuarios.usuario_id);            
            cmd.Parameters.AddWithValue("@id", objContrato_usuarios.contrato_usuario_id);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            Conectar();
            string sql = "delete from contrato_usuarios where id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}