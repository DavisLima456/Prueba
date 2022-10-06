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
    public class Datos_Donacion
    {

        public List<Donacion> Listar()
        {
            List<Donacion> lista = new List<Donacion>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "SELECT d.IdDonacion, d.Donante, d.MontoDonado, f.IdFundacion, f.NombreFundacion, d.FechaDonacion FROM DONACION d INNER JOIN FUNDACION f ON d.IdFundacion = f.IdFundacion";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Donacion()
                            {
                                IdDonacion = Convert.ToInt32(dr["IdDonacion"]),
                                Donante = dr["Donante"].ToString(),
                                MontoDonado = Convert.ToDecimal(dr["MontoDonado"]),
                                oFundacion = new Fundacion() {IdFundacion = Convert.ToInt32(dr["IdFundacion"]), NombreFundacion = dr["NombreFundacion"].ToString()},
                                Fecha = dr["FechaDonacion"].ToString()
                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Donacion>();
            }

            return lista;
        }

        public int Registrar(Donacion obj, out string Mensaje)
        {
            int idautogenerado = 0;

            Mensaje = string.Empty;
            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_RegistrarDonacion", oconexion);

                    cmd.Parameters.AddWithValue("Donante", obj.Donante);
                    cmd.Parameters.AddWithValue("MontoDonado", obj.MontoDonado);
                    cmd.Parameters.AddWithValue("Fundacion", obj.oFundacion.IdFundacion);

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


        public bool Editar(Donacion obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("Sp_EditarDonacion", oconexion);
                    cmd.Parameters.AddWithValue("IdDonacion", obj.IdDonacion);
                    cmd.Parameters.AddWithValue("Donante", obj.Donante);
                    cmd.Parameters.AddWithValue("MontoDonado", obj.MontoDonado);
          
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
                    SqlCommand cmd = new SqlCommand("Sp_Eliminar_Donacion", oconexion);
                    cmd.Parameters.AddWithValue("IdDonacion", id);
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
