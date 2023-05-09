using System.ComponentModel.DataAnnotations;

namespace CRM_Ucompensar.Models.Usuario
{
    public class TipoDocumento
    {
        [Key]
        public int IdTipoDocumento { get; set; }
        public string? Descripcion { get; set; }
    }
}
