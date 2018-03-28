using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CompraVenta.UI.Models
{
    public class AbonoModels
    {
        public int Id { set; get; }
        public int IdPrestamo { set; get; }
        [DataType(DataType.Text)]
        [Range(1, int.MaxValue, ErrorMessage = "No se admiten montos iguales a 0")]
        [RegularExpression(@"^[0-9''-'\s]{1,100}$", ErrorMessage = "Solo se permiten números")]
        [Required(ErrorMessage = "El campo Monto es requerido")]
        public decimal Monto { set; get; }
        public int Estado { set; get; }
        public DateTime Fecha { set; get; }
        [MaxLength(128)]
        public string Id_AspNetUser { set; get; }

        public String LosEstadosDelAbono
        {
            get
            {
                if (Estado == (int)Model.Enumerados.EstadoAbono.Registrado)
                {
                    return "Registrado";
                }
                else
                {
                    return "Anulado";
                }

            }

        }


        [Display(Name = "Nombre del cliente")]
        public string NombreClientes { set; get; }
        [Display(Name = "Fecha del préstamo")]
        public DateTime FechaPrestamo { set; get; }
        [Display(Name = "Fecha de vencimiento")]
        public DateTime FechaVencimiento { set; get; }
        [Display(Name = "Cantidad de días")]
        public int CantidadDias { set; get; }
        [Display(Name = "Porcentaje de interés")]
        public double PorcentajeInteres { set; get; }
        [Display(Name = "Monto Pendiente de pago")]
        public double MontoPendientePago { set; get; }
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { set; get; }
        [Display(Name = "Cantidad prestada")]
        public decimal CantidadPrestada { set; get; }









    }
}