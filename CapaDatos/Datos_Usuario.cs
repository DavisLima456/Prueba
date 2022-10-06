using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad1;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class Datos_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> listar = new List<Usuario>();


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT ID_USUARIO, NOMBRE, APELLIDO, CORREO,CLAVE, ROL, ACTIVO FROM USUARIO";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listar.Add(
                                new Usuario()
                                {
                                    ID_USUARIO = Convert.ToInt32(reader["ID_USUARIO"]),
                                    NOMBRE = reader["NOMBRE"].ToString(),
                                    APELLIDO = reader["APELLIDO"].ToString(),
                                    CORREO = reader["CORREO"].ToString(),
                                    CLAVE = reader["CLAVE"].ToString(),
                                    ROL = Convert.ToInt32(reader["ROL"]),
                                
                                    ACTIVO = Convert.ToBoolean(reader["ACTIVO"])

                                }

                                );
                        }
                    }
                }

            }
            catch
            {
                listar = new List<Usuario>();

            }




            return listar;
        }

        //registrar un usuario
        public int Registrar(Usuario obj, out string Mensaje)
        {
            int id_autogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_RegistrarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.NOMBRE);
                    cmd.Parameters.AddWithValue("Apellido", obj.APELLIDO);
                    cmd.Parameters.AddWithValue("Correo", obj.CORREO);
                    cmd.Parameters.AddWithValue("Clave", obj.CLAVE);
                    cmd.Parameters.AddWithValue("Activo", obj.ACTIVO);
                    cmd.Parameters.AddWithValue("Rol", obj.ROL);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    id_autogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                id_autogenerado = 0;
                Mensaje = ex.Message;
            }

            return id_autogenerado;

        }

        //editar 
        public bool Editar(Usuario obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EditarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.ID_USUARIO);
                    cmd.Parameters.AddWithValue("Nombre", obj.NOMBRE);
                    cmd.Parameters.AddWithValue("Apellido", obj.APELLIDO);
                    cmd.Parameters.AddWithValue("Correo", obj.CORREO);
                    cmd.Parameters.AddWithValue("Activo", obj.ACTIVO);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false; ;
                Mensaje = ex.Message;
            }

            return resultado;

        }

        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top(1) from Usuario where ID_USUARIO = @id", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;



        }
    }

}
