namespace Demo_DataAnnotations.Models.DBModels
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string NumeroCelular { get; set; }
        public string CorreoElectronico { get; set; }
        public string Password { get; set; }
    }
}