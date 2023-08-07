using ProyectoXDDD.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoXDDD.Datos
{
    public class UsuarioDatos
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            var cn = new Conexion();


            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {

                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuario
                        {
                            IDUSUARIO = Convert.ToInt32(dr["IDUSUARIO"]),
                            Nombre = dr["Nombre"].ToString(),
                            Email = dr["Email"].ToString(),
                            Contrasenia = dr["Contrasenia"].ToString()
                        });
                    }
                }
            }

            return lista;

        }

        public Usuario ObtenerUsuario(int IDUSUARIO)
        {
            Usuario _usuario = new Usuario();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerUsuario", conexion);
                cmd.Parameters.AddWithValue("IDUSUARIO", IDUSUARIO);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        _usuario.IDUSUARIO = Convert.ToInt32(dr["IDUSUARIO"]);
                        _usuario.Nombre = dr["Nombre"].ToString();
                        _usuario.Email = dr["Email"].ToString();
                        _usuario.Contrasenia = dr["Contrasenia"].ToString();

                    }
                }
            }
            return _usuario;

        }
        //GUARDAR CONTACTO XD
        public bool GuardarContacto(Usuario model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarUsuario", conexion);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Email", model.Email);
                    cmd.Parameters.AddWithValue("Contrasenia", model.Contrasenia);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }

            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }
        //hola mundo
        public bool ActualizarContacto(int id, Usuario model)
        {

            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_ActualizarUsuario", conexion);

                    cmd.Parameters.AddWithValue("IDUSUARIO", model. IDUSUARIO);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Email", model.Email);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }

            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public bool EliminarUsuario(int IDUSUARIO)
        {

            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IDUSUARIO", IDUSUARIO);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }

            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

    }
}
