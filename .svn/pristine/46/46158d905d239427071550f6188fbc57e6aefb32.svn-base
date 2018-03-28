using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompraVenta.UI.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Nombre es requerido.")]
        [Display(Name = "Nombre")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Clave es requerida.")]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string Password { get; set; }

        [Display(Name = "Recordar Sesión?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        
        [Required(ErrorMessage = "Nombre es requerido.")]
        [Display(Name = "Nombre")]
        //[System.Web.Mvc.Remote("Nombre", ErrorMessage = "El usuario ya existe.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Correo Electrónico es requerido.")]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        
        public string Email { get; set; }

        [Required(ErrorMessage = "Clave es requerida")]
        [StringLength(100, ErrorMessage = "El {0} al menos debe ser {2} caracteres.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmar la clave es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar la Clave")]
        [Compare("Password", ErrorMessage = "Clave y Confirmar la Clave no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El {0} al menos debe ser {2} caracteres.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
