using CRM_Ucompensar.Models.usuario;
using CRM_Ucompensar.Models.Usuario;
using Microsoft.EntityFrameworkCore;

namespace CRM_Ucompensar.Context
{
    public class ConexionSQL: DbContext
    {
        public ConexionSQL(DbContextOptions <ConexionSQL> db) : base(db){ 
        }

        public DbSet<Rol> Rols { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
