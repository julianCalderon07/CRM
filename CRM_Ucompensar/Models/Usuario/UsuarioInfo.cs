using CRM_Ucompensar.Models.usuario;

namespace CRM_Ucompensar.Models.Usuario
{
    public class UsuarioInfo
    {
        public Usuarios? Usuario { get; set; }
        public Rol? Rol { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }
    }

}
