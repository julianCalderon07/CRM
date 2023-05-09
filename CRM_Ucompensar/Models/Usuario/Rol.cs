using System.ComponentModel.DataAnnotations;

namespace CRM_Ucompensar.Models.usuario
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string? Descripcion { get; set; }
    }
}
