using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CompraVenta.UI.Models
{
    public class PrestamosModels
    {

        [Display(Name = "Id del préstamo")]
        public int Id { set; get; }
        public int IdCliente { set; get; }
        [Display(Name = "Fecha del préstamo")]
        public DateTime Fecha { set; get; }
        [DataType(DataType.Text)]
        [Range(1, double.MaxValue, ErrorMessage = "No se admiten montos iguales a 0")]
        [Required(ErrorMessage = "El campo Cantidad Prestada es requerido")]
        [RegularExpression(@"^[0-9''-'\s]{1,100}$", ErrorMessage = "Solo se permiten números y mayores a 0")]
        [Display(Name = "Cantidad prestada")]
        public decimal CantidadPrestada { set; get; }
        [Display(Name = "Porcentaje de interés")]
        public double PorcentajeIntereses { set; get; }
        [Required(ErrorMessage = "El campo Plazo del préstamo es requerido")]
        [Display(Name = "Plazo en días")]
        public int PlazoDiasPrestamo { set; get; }
        [MaxLength(128)]
        public string Id_AspNetUser { set; get; }
        [Required(ErrorMessage = "El campo Descripción de la prenda  es requerido")]
        [Display(Name = "Descripción de la prenda")]
        public string DescripcionPrenda { set; get; }
        public int Estado { set; get; }
        
       
        public List<Model.PrestamoDiasPrestamo> laListaDePlazoDiasPrestamo;

        public IEnumerable<SelectListItem> ListaDePlazoDiasPrestamo
        {
            get { return new SelectList(laListaDePlazoDiasPrestamo, "Id","Nombre"); }
        }



        public List<Model.Abono.Abono> AbonosDelPrestamo;

        [Display(Name = "Fecha vencimiento")]
        public DateTime FechaVencimiento
        {
            get
            {

                return Fecha.AddDays(PlazoDiasPrestamo);
            }
        }
        [Display(Name = "Monto Pendiente de pago")]
        public double MontoPendienteDePago { set; get; }

        [Display(Name = "Estado")]
        public String LosEstadosDelPrestamo
        {
            get
            {
                if (Estado == (int)Model.Enumerados.EstadoPrestamo.Registrado)
                {
                    return "Registrado";
                }

                return "Registrado";
            }

        }

        [Display(Name = "Nombre del cliente")]
        public string NombreClientes { set; get; }
        [Range(0, int.MaxValue, ErrorMessage = "El Campo cedula solo admite numeros")]
        [Required(ErrorMessage = "El campo Cedula Cliente es requerido")]
        [Display(Name = "Cedula del cliente")]
        public string CedulaCliente { set; get; }
        [Required(ErrorMessage = "El campo correo electronico del Cliente es requerido")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "El Email tiene formato invalido")]
        [Display(Name = "Email")]
        public string Email { set; get; }

        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { set; get; }

    }
}