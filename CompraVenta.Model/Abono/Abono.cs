using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraVenta.Model.Abono
{
   public class Abono
    {
        public int Id { set; get; }
        public int IdPrestamo { set; get; }
        public decimal Monto { set; get; }
        public int Estado { set; get; }
        public DateTime Fecha { set; get; }
        public string Id_AspNetUser { set; get; }

    }
}
