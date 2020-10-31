using System.ComponentModel.DataAnnotations;

namespace Demo_DataAnnotations.DTOs
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Únicamente se aceptan entre 1 a 150 caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Phone(ErrorMessage = "Ingrese un número telefónico válido")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Se aceptan entre 7 o más dígitos")]
        public string NumeroCelular { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Únicamente se aceptan entre 1 a 150 caracteres")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(100, ErrorMessage = "La contraseña es muy corta", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}