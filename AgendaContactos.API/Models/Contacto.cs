namespace AgendaContacto.API.Models
{
    public class Contacto
    {
        public int Id { get; set;}
        public string Nombre { get; set;} = string.Empty;
        public string? Telefono { get; set;}
        public string? Correo { get; set;}
    }
}