using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Valorizaciones.Models;

namespace Valorizaciones.Datos
{
    public class Usuario_tipoAdmin : Conexion
    {
        public IEnumerable<Usuario_tipoModel> ConsultarAll()
        {
            Conectar();
            List<Usuario_tipoModel> lista = new List<Usuario_tipoModel>();
            string sql = "SELECT usu.id usuario_id, usuario, correo, numero_documento, tipo_usuario_id, password, tus.tipo_usuario FROM usuarios usu INNER JOIN tipo_usuarios tus ON tus.id = usu.tipo_usuario_id WHERE usu.eliminado = 0 ";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Usuario_tipoModel objUsuario_tipo = new Usuario_tipoModel();
                objUsuario_tipo.usuario_id = Convert.ToInt32(reader["usuario_id"]);
                objUsuario_tipo.usuario = reader["usuario"].ToString();
                objUsuario_tipo.correo = reader["correo"].ToString();
                objUsuario_tipo.numero_documento = reader["numero_documento"].ToString();
                objUsuario_tipo.tipo_usuario_id = Convert.ToInt32(reader["tipo_usuario_id"]);
                objUsuario_tipo.password = reader["password"].ToString();
                objUsuario_tipo.tipo_usuario = reader["tipo_usuario"].ToString();
                lista.Add(objUsuario_tipo);
            }
            return lista;
        }
        
        public IEnumerable<Usuario_tipoModel> ConsultarItem(int id)
        {
            Conectar();
            List<Usuario_tipoModel> lista = new List<Usuario_tipoModel>();                
            string update = "SELECT usu.id usuario_id, usuario, correo, numero_documento, tipo_usuario_id, password, tus.tipo_usuario FROM usuarios usu INNER JOIN tipo_usuarios tus ON tus.id = usu.tipo_usuario_id WHERE usu.id = " + id;
            SqlCommand comando = new SqlCommand(update, cnn);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Usuario_tipoModel objUsuario_tipo = new Usuario_tipoModel();
                objUsuario_tipo.usuario_id          = Convert.ToInt32(reader["usuario_id"]);
                objUsuario_tipo.usuario             = reader["usuario"].ToString();
                objUsuario_tipo.correo = reader["correo"].ToString();
                objUsuario_tipo.numero_documento    = reader["numero_documento"].ToString();
                objUsuario_tipo.tipo_usuario_id     = Convert.ToInt32(reader["tipo_usuario_id"]);
                objUsuario_tipo.password            = reader["password"].ToString();
                objUsuario_tipo.tipo_usuario        = reader["tipo_usuario"].ToString();
                lista.Add(objUsuario_tipo);
            }           
            return lista;
        }

        public Usuario_tipoModel ConsultarItemObj(int id)
        {
            Conectar();
            Usuario_tipoModel objUsuario_tipo = new Usuario_tipoModel();
            try
            {
                string update = "SELECT usu.id usuario_id, usuario, correo, numero_documento, tipo_usuario_id, password, tus.tipo_usuario FROM usuarios usu INNER JOIN tipo_usuarios tus ON tus.id = usu.tipo_usuario_id WHERE usu.id = " + id;
                SqlCommand comando = new SqlCommand(update, cnn);

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    objUsuario_tipo.usuario_id = Convert.ToInt32(reader["usuario_id"]);
                    objUsuario_tipo.usuario = reader["usuario"].ToString();
                    objUsuario_tipo.correo = reader["correo"].ToString();
                    objUsuario_tipo.numero_documento = reader["numero_documento"].ToString();
                    objUsuario_tipo.tipo_usuario_id = Convert.ToInt32(reader["tipo_usuario_id"]);
                    objUsuario_tipo.password = reader["password"].ToString();
                    objUsuario_tipo.tipo_usuario = reader["tipo_usuario"].ToString();
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
            return objUsuario_tipo;
        }

        public IEnumerable<Usuario_tipoModel> ConsultarBuscador(string parametro)
        {
            Conectar();
            List<Usuario_tipoModel> lista = new List<Usuario_tipoModel>();
            string sql = "SELECT usu.id usuario_id, usuario, correo, numero_documento, tipo_usuario_id, password, tus.tipo_usuario FROM usuarios usu INNER JOIN tipo_usuarios tus ON tus.id = usu.tipo_usuario_id WHERE usuario LIKE  '%" + parametro + "%'";
            SqlCommand comando = new SqlCommand(sql, cnn);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Usuario_tipoModel objUsuario_tipo = new Usuario_tipoModel();
                objUsuario_tipo.usuario_id = Convert.ToInt32(reader["usuario_id"]);
                objUsuario_tipo.usuario = reader["usuario"].ToString();
                objUsuario_tipo.correo = reader["correo"].ToString();
                objUsuario_tipo.value = reader["usuario"].ToString();
                objUsuario_tipo.numero_documento = reader["numero_documento"].ToString();
                objUsuario_tipo.tipo_usuario_id = Convert.ToInt32(reader["tipo_usuario_id"]);
                objUsuario_tipo.password = reader["password"].ToString();
                objUsuario_tipo.tipo_usuario = reader["tipo_usuario"].ToString();
                lista.Add(objUsuario_tipo);
            }
            return lista;
        }

        public void Insert(UsuariosModel objUsuario)
        {
            Conectar();
            string sql = "insert into usuarios (usuario, correo, numero_documento, tipo_usuario_id, password,eliminado) values (@usuario, @correo, @numero_documento, @tipo_usuario_id, @password,'0')";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@usuario", objUsuario.usuario);
            cmd.Parameters.AddWithValue("@correo", objUsuario.correo);
            cmd.Parameters.AddWithValue("@numero_documento", objUsuario.numero_documento);
            cmd.Parameters.AddWithValue("@tipo_usuario_id", objUsuario.tipo_usuario_id);
            cmd.Parameters.AddWithValue("@password", objUsuario.password);
            cmd.ExecuteNonQuery();
        }

        public void Update(Usuario_tipoModel objUsuario_tipo)
        {
            Conectar();
            string sql = "update usuarios set usuario = @usuario, correo = @correo, numero_documento = @numero_documento, tipo_usuario_id = @tipo_usuario_id, password = @password WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@usuario", objUsuario_tipo.usuario);
            cmd.Parameters.AddWithValue("@correo", objUsuario_tipo.correo);
            cmd.Parameters.AddWithValue("@numero_documento", objUsuario_tipo.numero_documento);
            cmd.Parameters.AddWithValue("@tipo_usuario_id", objUsuario_tipo.tipo_usuario_id);
            cmd.Parameters.AddWithValue("@password", objUsuario_tipo.password);
            cmd.Parameters.AddWithValue("@id", objUsuario_tipo.usuario_id);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            Conectar();
            string sql = "DELETE FROM usuarios WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void Delete_update(int id)
        {
            Conectar();
            string sql = "UPDATE usuarios SET eliminado =  1 WHERE id = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}