namespace Demo_DataAnnotations.Models.DBModels
{
    public partial class Clientes
    {
        public int CodCliente { get; set; }
        public string NombreCliente { get; set; }
        public string NombreNegocio { get; set; }
        public string Rtn { get; set; }
        public string DireccionNegocio { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroTelefono { get; set; }
        public string ContactoPrincipal { get; set; }
        public bool Activo { get; set; }
        public int? CodCategoriaCliente { get; set; }

        public virtual CategoriaCliente CodCategoriaClienteNavigation { get; set; }
    }
}