using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad1;
using System.Data;
namespace CapaDatos
{
    public class Datos_ListarAgenda
    {
        public List<ListarAgenda> Listar(int IdEspecialista)
        {
            List<ListarAgenda> lista = new List<ListarAgenda>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("List_Agenda", oconexion);
                    cmd.Parameters.AddWithValue("IdEspecialidad", IdEspecialista);

                    cmd.CommandType = CommandType.StoredProcedure;


                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ListarAgenda()
                            {
                                IdEspcialista = Convert.ToInt32(dr["No SOLICITUD"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                MotivoVisita = dr["Motivo de Visita"].ToString(),
                                horario = dr["Horario"].ToString(),

                            }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<ListarAgenda>();
            }

            return lista;
        }
    }
}
