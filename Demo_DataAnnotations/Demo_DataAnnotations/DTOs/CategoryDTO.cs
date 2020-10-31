using System.ComponentModel.DataAnnotations;

namespace Demo_DataAnnotations.DTOs
{
    public class CategoryDTO
    {
        public int CodCategoriaCliente { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(900, ErrorMessage = "Únicamente se aceptan entre 1 a 900 caracteres")]
        public string NombreCategoriaCliente { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(900, ErrorMessage = "Únicamente se aceptan entre 1 a 900 caracteres")]
        public string DescripcionCategoriaCliente { get; set; }

        public bool Activo { get; set; }
    }
}