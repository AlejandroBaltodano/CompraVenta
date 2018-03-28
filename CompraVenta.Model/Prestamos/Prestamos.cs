using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraVenta.Model.Prestamos
{
   public class Prestamos
    {

        public int Id { set; get; }
        public int IdCliente { set; get; }
        public DateTime Fecha { set; get; }
        public decimal CantidadPrestada { set; get; }
        public double PorcentajeIntereses { set; get; }
        public int PlazoDiasPrestamo { set; get; }
        public string Id_AspNetUser { set; get; }
        public string DescripcionPrenda { set; get; }
        public int Estado { set; get; }

      
    }
}
