namespace CRM.Entities
{
    public class Usuario
    {
        public string? Contrasena { get; set; }
        public string? Correo { get; set; }
        public string? Documento { get; set; }
        public bool Estado { get; set; }
        public int Id { get; set; }
        public int IdRol { get; set; }
        public int IdTipoDocumento { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? UsuarioSystem { get; set; }
    }
}