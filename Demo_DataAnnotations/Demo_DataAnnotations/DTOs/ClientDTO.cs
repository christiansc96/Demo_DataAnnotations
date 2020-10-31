using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo_DataAnnotations.DTOs
{
    public class ClientDTO : IValidatableObject
    {
        public int CodCliente { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [StringLength(900, MinimumLength = 1, ErrorMessage = "Únicamente se aceptan entre 1 a 900 caracteres")]
        public string NombreCliente { get; set; }

        [MaxLength(900, ErrorMessage = "Únicamente se aceptan entre 1 a 900 caracteres")]
        public string NombreNegocio { get; set; }

        [MaxLength(900, ErrorMessage = "Únicamente se aceptan entre 1 a 900 caracteres")]
        public string RTN { get; set; }

        public string DireccionNegocio { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Phone(ErrorMessage = "Ingrese un número telefónico válido")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Se aceptan entre 7 o más dígitos")]
        public string NumeroTelefono { get; set; }

        [MaxLength(900, ErrorMessage = "Únicamente se aceptan entre 1 a 900 caracteres")]
        public string ContactoPrincipal { get; set; }

        public bool Activo { get; set; }

        public Nullable<int> CodCategoriaCliente { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            bool validateIfBussinesName = String.IsNullOrEmpty(this.NombreNegocio) && (!String.IsNullOrEmpty(this.RTN));
            if (validateIfBussinesName)
            {
                yield return new
                    ValidationResult(
                    "nombreNegocio no es permitido ir vacío",
                    new[]
                    {
                        "nombreNegocio"
                    });
            }

            bool validateIfRTN = String.IsNullOrEmpty(this.RTN) && (!String.IsNullOrEmpty(this.NombreNegocio));
            if (validateIfRTN)
            {
                yield return new
                    ValidationResult(
                    "RTN no es permitido ir vacío",
                    new[]
                    {
                        "RTN"
                    });
            }
        }
    }
}