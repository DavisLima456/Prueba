using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad1;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace CapaDatos
{
    public class Datos_CostosMedico
    {

        //Metodo para mostrar los examenes
        public List<CostoMedico> Listar(int IdCita)
        {
            List<CostoMedico> lista = new List<CostoMedico>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_Mostrar_Gasto", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new CostoMedico()
                            {
                                oCitaMedica = new CitaMedica() { IdCita = Convert.ToInt32(dr["IdCita"])},



                                oIdDetalleCita = new DetalleCita() { IdDetalleCita = Convert.ToInt32(dr["IdDetalleCita"]), Nombre = dr["Nombre"].ToString(), Descripcion = dr["Descripcion"].ToString() },


                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<CostoMedico>();
            }

            return lista;
        }

        //Metodo para listar los Medicamentos
        public List<CostoMedico> Listar_Medicamento(int IdCita)
        {
            List<CostoMedico> lista = new List<CostoMedico>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_Mostrar_Medicamento", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new CostoMedico()
                            {
                                oCitaMedica = new CitaMedica() { IdCita = Convert.ToInt32(dr["IdCita"]) },



                                oIdDetalleCita = new DetalleCita() { IdDetalleCita = Convert.ToInt32(dr["IdDetalleCita"]), Nombre = dr["Nombre"].ToString(), Descripcion = dr["Descripcion"].ToString() },


                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<CostoMedico>();
            }

            return lista;
        }




        //Metodo para asignar un examen. 
        public int Registrar(CostoMedico obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_Asignar_Examen", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", obj.oCitaMedica.IdCita);
                    cmd.Parameters.AddWithValue("IdDetalleCita", obj.oIdDetalleCita.IdDetalleCita);
                    cmd.Parameters.AddWithValue("Cantidad", obj.Cantidad);


                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                   
                    idautogenerado = Convert.ToInt32(cmd.Parameters["IdCita"].Value.ToString());

                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (IOException ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }


        //metodo para eliminar una asignacion de examen 
        public bool Eliminar(int id, int i, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("DELETE TOP(1) COSTO_MEDICO WHERE IdCita = @id AND IdDetalleCita = @i", oconexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@i", i);
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


        //Metodo para listar la informacion del paciente
        public VerPaciente List_Paciente(int IdCita)
        {
            VerPaciente objeto = new VerPaciente();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("LIST_PACIENTES", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            objeto = new VerPaciente()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                Fecha = dr["Fecha"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Medico = dr["Medico"].ToString(),
                                Padecimientos = dr["Padecimientos"].ToString(),
                                MotivoVisita = dr["MotivoVista"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                            
                            };
                        }
                    }

                }
            }
            catch
            {
                objeto = new VerPaciente();
            }

            return objeto;
        }

        //para visualizar la citas
        public List<VistaCita> DetalleCita(int IdCita)
        {
            List<VistaCita> lista = new List<VistaCita>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("Sp_Detalle", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new VistaCita()
                            {



                                Descripcion = dr["Descripcion"].ToString(),
                                Precio = Convert.ToDecimal(dr["Precio"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"])



                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<VistaCita>();
            }

            return lista;
        }


        public TotalCita Totalcita(int IdCita)
        {
            TotalCita objeto = new TotalCita();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("Sp_CalcularTotal", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            objeto = new TotalCita()
                            {

                                Total = Convert.ToDecimal(dr["Total"])
                            };
                        }
                    }

                }
            }
            catch
            {
                objeto = new TotalCita();
            }

            return objeto;
        }

        public VerCitas VerCitas(int IdCita)
        {
            VerCitas objeto = new VerCitas();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {


                    SqlCommand cmd = new SqlCommand("Sp_Visita", oconexion);
                    cmd.Parameters.AddWithValue("IdCita", IdCita);
                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            objeto = new VerCitas()
                            {

                                Correo = dr["Correo"].ToString(),
                                Paciente = dr["Paciente"].ToString(),
                                Edad = Convert.ToInt32(dr["Edad"]),
                                Acompanante = dr["Acompanante"].ToString(),
                                Especialista = dr["Especialista"].ToString(),
                                Dpi = dr["DPI"].ToString(),
                                


                            };
                        }
                    }

                }
            }
            catch
            {
                objeto = new VerCitas();
            }

            return objeto;
        }





    }
}
