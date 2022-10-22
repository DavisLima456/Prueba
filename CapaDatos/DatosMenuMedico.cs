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
    public class DatosMenuMedico
    {
        public MenuMedico verMenu()
        {
             MenuMedico objeto = new MenuMedico();


            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                   
                    SqlCommand cmd = new SqlCommand("Sp_ReporteMenu", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            objeto = new MenuMedico()
                            {
                                CantidadPacientes = Convert.ToInt32(reader["CantidadPacientes"]),
                                CantidadSolicitud = Convert.ToInt32(reader["CantidadSolicitud"]),
                            };


                        }
                    }
                }

            }
            catch
            {
                objeto = new MenuMedico();

            }




            return objeto;
        }
    }
}
