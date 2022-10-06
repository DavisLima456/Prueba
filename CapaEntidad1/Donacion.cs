using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad1
{
    public class Donacion
    {
        public int IdDonacion { get; set; }
        public string Donante { get; set; }
        public decimal MontoDonado { get; set; }
        public Fundacion oFundacion { get; set; }
        public string Fecha { get; set; }


    }
}
