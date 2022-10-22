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
    public class Datos_Reportes
    {
        public List<Reporte1> ListarReporte1(int IdTipo)
        {
            List<Reporte1> lista = new List<Reporte1>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("Sp_Reporte1", oconexion);
                    cmd.Parameters.AddWithValue("IdTipo", IdTipo);

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte1()
                            {
                                No_Cita = Convert.ToInt32(dr["No Cita"]),
                                Cod_Paciente = Convert.ToInt32(dr["COD_PACIENTE"]),
                                Paciente = dr["Paciente"].ToString(),
                                CostoCita = Convert.ToDecimal(dr["Costo de Cita"]),
                                Exa_Med = dr["Examen o Medicamento"].ToString(),
                                Costo_ExaMed = Convert.ToDecimal(dr["Costo de Examen o Medicamento"]),


                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte1>();
            }

            return lista;
        }
        public List<Reporte1> Ventas()
        {
            List<Reporte1> lista = new List<Reporte1>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("Sp_ReporteExc", oconexion);

                  
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte1()
                            {
                                No_Cita = Convert.ToInt32(dr["No Cita"]),
                                Cod_Paciente = Convert.ToInt32(dr["COD_PACIENTE"]),
                                Paciente = dr["Paciente"].ToString(),
                                CostoCita = Convert.ToDecimal(dr["Costo de Cita"]),
                                Exa_Med = dr["Examen o Medicamento"].ToString(),
                                Costo_ExaMed = Convert.ToDecimal(dr["Costo de Examen o Medicamento"]),


                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte1>();
            }

            return lista;
        }

        public List<ReporteCitas> ReporteCitas(string fechainicio, string fechafin)
        {
            List<ReporteCitas> lista = new List<ReporteCitas>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("Sp_ReporteCitas", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteCitas()
                            {
                                FechaIngreso = dr["Fecha Ingreso"].ToString(),
                                Paciente = dr["Paciente"].ToString(),
                                Medico = dr["Medico"].ToString(),     
                                PrecioCita = Convert.ToDecimal(dr["PrecioCita"]),
                                Cantidad = Convert.ToInt32(dr["Cantidad"]),


                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<ReporteCitas>();
            }

            return lista;
        }

        public List<Reporte2> ListarReporte2()
        {
            List<Reporte2> lista = new List<Reporte2>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("Sp_AnalisisMedico ", oconexion);


                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte2()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                Paciente = dr["Paciente"].ToString(),
                                Cintomas = dr["Cintomas"].ToString(),
                                Medicamentos = dr["Medicamentos"].ToString(),
                                Examenes = dr["Examanes"].ToString(),


                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte2>();
            }

            return lista;
        }

        public List<Reporte3> ListarReporte3(string fechainicio, string fechafin)
        {
            List<Reporte3> lista = new List<Reporte3>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("SP_Reporte3 ", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte3()
                            {
                                FechaIngreso = dr["Fecha"].ToString(),
                                Paciente = dr["Paciente"].ToString(),
                                Total = Convert.ToDecimal( dr["Total"]),
                                Descripcion = dr["Descripcion"].ToString(),
                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte3>();
            }

            return lista;
        }

        public List<Reporte4> ListarReporte4()
        {
            List<Reporte4> lista = new List<Reporte4>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("Sp_Reporte4", oconexion);
                  

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte4()
                            {
                                IdMensualidad = Convert.ToInt32( dr["IdMensualidad"]),
                                PACIENTE = dr["PACIENTE"].ToString(),
                                Monto = Convert.ToDecimal(dr["Monto"]),
                                Fecha = dr["Fecha"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                NombreMes = dr["NombreMes"].ToString(),
                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte4>();
            }

            return lista;
        }

        public List<Reporte5> ListarReporte5()
        {
            List<Reporte5> lista = new List<Reporte5>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("Sp_Reporte5", oconexion);


                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte5()
                            {
                                Fecha = dr["Fecha"].ToString(),
                                Persona = dr["Persona"].ToString(),
                               
                                Cantidad = Convert.ToDecimal(dr["Cantidad"]),
                                
                                Descripcion = dr["Descripcion"].ToString(),
                        
                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte5>();
            }

            return lista;
        }

        public List<Reporte6> ListarReporte6()
        {
            List<Reporte6> lista = new List<Reporte6>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("Sp_Reporte6", oconexion);


                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte6()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                Paciente = dr["Paciente"].ToString(),

                                Cantidad = Convert.ToInt32(dr["Cantidad"]),

                                Examen = dr["Examanes"].ToString(),

                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte6>();
            }

            return lista;
        }

        public List<Reporte7> ListarReporte7()
        {
            List<Reporte7> lista = new List<Reporte7>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("Sp_Reporte7", oconexion);


                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Reporte7()
                            {
                                IdCita = Convert.ToInt32(dr["IdCita"]),
                                Paciente = dr["Paciente"].ToString(),

                                Cantidad = Convert.ToInt32(dr["Cantidad"]),

                                Medicamento = dr["Medicamentos"].ToString(),

                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reporte7>();
            }

            return lista;
        }

    }
}
