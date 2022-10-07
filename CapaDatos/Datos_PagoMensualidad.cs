using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad1;


namespace CapaDatos
{
    public class Datos_PagoMensualidad
    {
        //para listar
        public List<Mensualidad> Listar()
        {
            List<Mensualidad> listar = new List<Mensualidad>();


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT m.IdMensualidad,p.COD_PACIENTE, concat(p.Nombre, ' ', p.Apellido)Paciente, m.Entrante[Familiar], m.Monto,ms.IdMes, ms.NombreMes, m.FECHA");
                    sb.AppendLine("FROM MENSUALIDAD m INNER JOIN PACIENTE p ON m.COD_PACIENTE=p.COD_PACIENTE");
                    sb.AppendLine("INNER JOIN MES ms ON ms.IdMes=m.IdMes");
                 

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listar.Add(
                                new Mensualidad()
                                {
                                    IdMensualidad = Convert.ToInt32(reader["IdMensualidad"]),                
                                    oPaciente = new Paciente() { COD_PACIENTE = Convert.ToInt32(reader["COD_PACIENTE"]), Nombre = reader["Paciente"].ToString() },
                                    Entrante = reader["Familiar"].ToString(),
                                    Monto = Convert.ToDecimal(reader["Monto"]),
                                    oMes = new Mes() { IdMes = Convert.ToInt32(reader["IdMes"]), NombreMes = reader["NombreMes"].ToString() },
                                    Fecha = reader["FECHA"].ToString(),
                                        
                                }

                                );
                        }
                    }
                }

            }
            catch
            {
                listar = new List<Mensualidad>();

            }




            return listar;
        }


        //METODO PARA INGRESAR UN Nuevo Pago de Mensualidad
        public int Registrar(Mensualidad obj, out string Mensaje)
        {
            int id_autogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_RegistrarPago", oconexion);
                   
                    cmd.Parameters.AddWithValue("Cod_Paciente", obj.oPaciente.COD_PACIENTE);
                    cmd.Parameters.AddWithValue("Entrante", obj.Entrante);
                    cmd.Parameters.AddWithValue("Monto", obj.Monto);
                    cmd.Parameters.AddWithValue("IdMes", obj.oMes.IdMes);

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

        //METODO PARA EDITAR UN PAGO DE MENSUALIDAD
        
        public bool Editar(Mensualidad obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EditarPago", oconexion);
                    cmd.Parameters.AddWithValue("IdMensualidad", obj.IdMensualidad);
                    cmd.Parameters.AddWithValue("Cod_Paciente", obj.oPaciente.COD_PACIENTE);
                    cmd.Parameters.AddWithValue("Entrante", obj.Entrante);
                    cmd.Parameters.AddWithValue("Monto", obj.Monto);
                    cmd.Parameters.AddWithValue("IdMes", obj.oMes.IdMes);
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


        //METODO PARA ELIMINAR UN PAGO MENSUALIDAD.
        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EliminarPago", oconexion);
                    cmd.Parameters.AddWithValue("IdMensualidad", id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
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
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }


    }
}
