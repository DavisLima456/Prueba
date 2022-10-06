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
    public class Datos_GastosGenerales
    {

        public List<GastosGenerales> Listar()
        {
            List<GastosGenerales> lista = new List<GastosGenerales>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "SELECT IdGastosGenerales, NombreGasto, Descripcion, MontoGasto, Fecha from GASTOSGENERALES";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new GastosGenerales()
                            {
                                IdGastosGenerales = Convert.ToInt32(dr["IdGastosGenerales"]),
                                NombreGasto = dr["NombreGasto"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                MontoGasto = Convert.ToDecimal(dr["MontoGasto"]),
                                Fecha = dr["Fecha"].ToString()

                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<GastosGenerales>();
            }

            return lista;
        }

        public int Registrar(GastosGenerales obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_GastosGenerales", oconexion);

                    cmd.Parameters.AddWithValue("NombreGasto", obj.NombreGasto);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("MontoGastos", obj.MontoGasto);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (IOException ex)
            {
                idautogenerado = 0;

                Console.WriteLine(ex.Message);
            }
            return idautogenerado;
        }


        public bool Editar(GastosGenerales obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarGastos", oconexion);
                    cmd.Parameters.AddWithValue("IdGastosGenerales", obj.IdGastosGenerales);
                    cmd.Parameters.AddWithValue("NombreGasto", obj.NombreGasto);
                    cmd.Parameters.AddWithValue("Precio", obj.MontoGasto);
                    cmd.Parameters.AddWithValue("Descripcion", obj.Descripcion);



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

        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_Eliminar_Gastos", oconexion);
                    cmd.Parameters.AddWithValue("IdGastosGenerales", id);
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
