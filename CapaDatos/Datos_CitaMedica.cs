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
    public class Datos_CitaMedica
    {

        //para listar
        public List<CitaMedica> Listar()
        {
            List<CitaMedica> listar = new List<CitaMedica>();


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT c.IdCita, c.FechaRegistro, m.IdMedico, m.Nombre[Medico], p.COD_PACIENTE, p.Nombre[Paciente], c.Cintomas, e.IdEspecialista, e.Nombre[Especialista],");
                    sb.AppendLine("en.IdEnfermero, en.Nombre[Enfermero], c.PrecioCita, t.NoTurno, t.Horario, es.IdEstado, es.Descripcion ");
                    sb.AppendLine("FROM CITAMEDICA c INNER JOIN MEDICO m on c.IdMedico=m.IdMedico");
                    sb.AppendLine("INNER JOIN PACIENTE p on p.COD_PACIENTE=c.COD_PACIENTE");
                    sb.AppendLine("INNER JOIN ESPECIALISTA e on e.IdEspecialista=c.IdEspecialista");
                    sb.AppendLine("INNER JOIN ENFERMERO en on en.IdEnfermero = c.IdEnfermero");
                    sb.AppendLine("INNER JOIN TURNO t on t.NoTurno=c.NoTurno");
                    sb.AppendLine("INNER JOIN ESTADO es on es.IdEstado=c.IdEstado");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listar.Add(
                                new CitaMedica()
                                {
                                    IdCita = Convert.ToInt32(reader["IdCita"]),
                                    FechaRegistro = reader["FechaRegistro"].ToString(),
                                    oMedico = new Medico() { IdMedico = Convert.ToInt32(reader["IdMedico"]), Nombre= reader["Medico"].ToString() },
                                    oPaciente = new Paciente() { COD_PACIENTE= Convert.ToInt32(reader["COD_PACIENTE"]), Nombre = reader["Paciente"].ToString() },
                                    Cintomas = reader["Cintomas"].ToString(),
                                    oEspecialista = new Especialista() { IdEspecialista = Convert.ToInt32(reader["IdEspecialista"]), Nombre = reader["Especialista"].ToString() },
                                    oEnfermero = new Enfermero() {  IdEnfermero = Convert.ToInt32(reader["IdEnfermero"]), Nombre = reader["Enfermero"].ToString() },
                                    PrecioCita = Convert.ToDecimal(reader["PrecioCita"]),
                                    oTurno = new Turno() { NoTurno = Convert.ToInt32(reader["NoTurno"]), Horario = reader["Horario"].ToString() },
                                    oEstado = new Estado() { IdEstado = Convert.ToInt32(reader["IdEstado"]), Descripcion = reader["Descripcion"].ToString() },
                                    
                              

                                }

                                );
                        }
                    }
                }

            }
            catch
            {
                listar = new List<CitaMedica>();

            }




            return listar;
        }


        //METODO PARA INGRESAR UNA NUEVA CITA (ficha medica)
        public int Registrar(CitaMedica obj, out string Mensaje)
        {
            int id_autogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_Registrar_CitaMedica", oconexion);
                    cmd.Parameters.AddWithValue("IdMedico", obj.oMedico.IdMedico);
                    cmd.Parameters.AddWithValue("COD_PACIENTE", obj.oPaciente.COD_PACIENTE);
                    cmd.Parameters.AddWithValue("Cintomas", obj.Cintomas);
                    cmd.Parameters.AddWithValue("IdEspecialista", obj.oEspecialista.IdEspecialista);
                    cmd.Parameters.AddWithValue("IdEnfermero", obj.oEnfermero.IdEnfermero);
                    cmd.Parameters.AddWithValue("PrecioCita", obj.PrecioCita);
                    cmd.Parameters.AddWithValue("NoTurno", obj.oTurno.NoTurno);
                    cmd.Parameters.AddWithValue("IdEstado", obj.oEstado.IdEstado);
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

        //METODO PARA EDITAR UNA CITA 
        public bool Editar(CitaMedica obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EditarCitaMedica", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", obj.IdCita);
                    cmd.Parameters.AddWithValue("IdMedico", obj.oMedico.IdMedico);
                    cmd.Parameters.AddWithValue("COD_PACIENTE", obj.oPaciente.COD_PACIENTE);
                    cmd.Parameters.AddWithValue("Cintomas", obj.Cintomas);
                    cmd.Parameters.AddWithValue("IdEspecialista", obj.oEspecialista.IdEspecialista);
                    cmd.Parameters.AddWithValue("IdEnfermero", obj.oEnfermero.IdEnfermero);
                    cmd.Parameters.AddWithValue("PrecioCita", obj.PrecioCita);
                    cmd.Parameters.AddWithValue("NoTurno", obj.oTurno.NoTurno);
                    cmd.Parameters.AddWithValue("IdEstado", obj.oEstado.IdEstado);
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
        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("DELETE TOP(1) FROM CITAMEDICA WHERE IdCita = @id", oconexion);
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

        //metodo para dar los resultados 
        public bool DarResultados(AsignarResultados obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_AsignarResultados", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", obj.IdCita);
                    cmd.Parameters.AddWithValue("Resultado1", obj.Resultados);


                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value.ToString());
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
