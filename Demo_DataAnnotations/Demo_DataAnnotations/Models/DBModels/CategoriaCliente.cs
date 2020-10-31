using System.Collections.Generic;

namespace Demo_DataAnnotations.Models.DBModels
{
    public partial class CategoriaCliente
    {
        public CategoriaCliente()
        {
            Clientes = new HashSet<Clientes>();
        }

        public int CodCategoriaCliente { get; set; }
        public string NombreCategoriaCliente { get; set; }
        public string DescripcionCategoriaCliente { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}