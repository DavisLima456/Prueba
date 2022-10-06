using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad1;
using CapaDatos;
namespace CapaNegocio
{
    public class CN_ListarAgenda
    {
        private Datos_ListarAgenda objCapaDato = new Datos_ListarAgenda();


        public List<ListarAgenda> listarAgenda(int IdEspecialista)
        {
            return objCapaDato.Listar(IdEspecialista);


        }

    }
}
