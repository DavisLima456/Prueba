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
    public class Datos_Paciente
    {


        //Metodo para  Listar los Pacientes Guardados 
        public List<Paciente> Listar()
        {
            List<Paciente> listar = new List<Paciente>();


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT COD_PACIENTE, Nombre, Apellido, Padecimientos, Enfermedades, Edad, Genero, Acompanante, MotivoVista ,FechaRegistro FROM PACIENTE";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listar.Add(
                                new Paciente()
                                {
                                    COD_PACIENTE = Convert.ToInt32(reader["COD_PACIENTE"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Apellido = reader["Apellido"].ToString(),
                                    Padecimientos = reader["Padecimientos"].ToString(),
                                    Enfermedades = reader["Enfermedades"].ToString(),
                                    Edad = Convert.ToInt32(reader["Edad"]),
                                    Genero = reader["Genero"].ToString(),
                                    Acompanante = reader["Acompanante"].ToString(),
                                    MotivoVista = reader["MotivoVista"].ToString(),
                                    FechaRegistro = reader["FechaRegistro"].ToString(),

                                }

                                );
                        }
                    }
                }

            }
            catch
            {
                listar = new List<Paciente>();

            }




            return listar;
        }

        // Metodo para Guardar un Paciente Nuevo.
        public int Registrar(Paciente obj, out string Mensaje)
        {
            int id_autogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_RegistrarPaciente", oconexion);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Padecimientos", obj.Padecimientos);
                    cmd.Parameters.AddWithValue("Enfermedades", obj.Enfermedades);
                    cmd.Parameters.AddWithValue("Edad", obj.Edad);
                    cmd.Parameters.AddWithValue("Dpi", obj.Dpi);
                    cmd.Parameters.AddWithValue("Genero", obj.Genero);
                    cmd.Parameters.AddWithValue("Acompanante", obj.Acompanante);
                    cmd.Parameters.AddWithValue("MotivoVista", obj.MotivoVista);
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

        //METODO PARA EDITAR UN PACIENTE. 
        public bool Editar(Paciente obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EditarPaciente", oconexion);
                    cmd.Parameters.AddWithValue("COD_PACIENTE", obj.COD_PACIENTE);
                    cmd.Parameters.AddWithValue("Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", obj.Apellido);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Padecimientos", obj.Padecimientos);
                    cmd.Parameters.AddWithValue("Enfermedades", obj.Enfermedades);
                    cmd.Parameters.AddWithValue("Edad", obj.Edad);
                    cmd.Parameters.AddWithValue("Dpi", obj.Dpi);
                    cmd.Parameters.AddWithValue("Genero", obj.Genero);
                    cmd.Parameters.AddWithValue("Acompanante", obj.Acompanante);
                    cmd.Parameters.AddWithValue("MotivoVista", obj.MotivoVista);
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

        //METODO PARA ELIMINAR UN PACIENTE.
        public bool Eliminar(int id , out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_Eliminar_Paciente", oconexion);
                    cmd.Parameters.AddWithValue("Cod_Paciente", id);
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





    }
}
