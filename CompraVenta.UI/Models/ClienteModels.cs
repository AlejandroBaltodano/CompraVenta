using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CompraVenta.UI.Models
{
    public class ClienteModels
    {
        public int Id { set; get; }
        [Range(0, int.MaxValue, ErrorMessage = "El Campo cedula solo admite numeros")]
        [Required(ErrorMessage = "El campo Cedula Cliente es requerido")]
        public string Cedula { set; get; }
        [Required(ErrorMessage = "El campo Nombre Completo Cliente es requerido")]
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { set; get; }
        [Required(ErrorMessage = "El campo Direccion del Cliente es requerido")]
        [Display(Name = "Dirección")]
        public string Direccion { set; get; }
        [Range(0, int.MaxValue, ErrorMessage = "Error. Verifique estas opciones:\n*El Campo Primer Telefóno Solo Acepta Números Ó *El Número Telefónico No Debe Sobrepasar Los 10 Dígitos")]
        [Required(ErrorMessage = "El campo Primer Telefono Cliente es requerido")]
        [Display(Name = "Telefono")]
        public string Telefono1 { set; get; }
        [Range(0, int.MaxValue, ErrorMessage = "Error. Verifique estas opciones:\n*El Campo Segundo Telefóno Solo Acepta Números Ó *El Número Telefónico No Debe Sobrepasar Los 10 Dígitos")]
        [Display(Name = "Segundo Telefono")]
        public string Telefono2 { set; get; }
        [Required(ErrorMessage = "El campo correo electronico del Cliente es requerido")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "El Email tiene formato invalido")]
        [Display(Name = "Email")]
        public string Email { set; get; }
        public int Estado { set; get; }
        [MaxLength(128)]
        public string Id_AspNetUser { set; get; }

        public String LosEstadosDelCliente
        {
            get
            {
                if (Estado == (int)Model.Enumerados.Estado.Activo)
                {
                    return "Activo";
                }
                else
                {
                    return "Inactivo";
                }

            }
        }


    }
}