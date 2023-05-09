using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_Ucompensar.Models.usuario
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        [ForeignKey("Rol")]
        public int IdRol { get; set; }
        public bool Estado { get; set; }
        [Required]
        public string? Documento { get; set; }
        [ForeignKey("TipoDocumento")]
        public int IdTipoDocumento { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? UsuarioSystem { get; set;}
        public string? contrasena { get; set; }
    }
}
