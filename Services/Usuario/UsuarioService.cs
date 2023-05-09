using CRM.Entities;
using CRM.Models;
using CRM.Utilities;
using System.Data;
using System.Runtime.InteropServices;

namespace CRM.Services
{
    internal class UsuarioService
    {
        #region Variables de clase

        /// <summary>
        /// Inicializacion del objeto ConnectionBD
        /// </summary>
        private readonly ConnectionDB _context = new();

        #endregion Variables de clase

        internal List<Usuario> GetAll()
        {
            try
            {
                DataTable dt;
                string sqlConsulta = Sentences.SELECT_ALL_USUARIOS;
                dt = this._context.Consultar(sqlConsulta);
                List<Usuario> usuarios = new();
                foreach (DataRow dr in dt.Rows)
                {
                    usuarios.Add(FillUsuarioData(dr));
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new ExternalException(ex.Message);
            }
        }

        internal Usuario GetById(int? id)
        {
            try
            {
                DataTable dt;
                string sqlConsulta = Sentences.SELECT_USUARIO_BY_ID.Replace("@ID", id.ToString());
                dt = this._context.Consultar(sqlConsulta);
                return FillUsuarioData(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new ExternalException(ex.Message);
            }
        }

        private static Usuario FillUsuarioData(DataRow dr)
        {
            return new Usuario()
            {
                Contrasena = dr["contrasena"].ToString(),
                Correo = dr["correo"].ToString(),
                Documento = dr["documento"].ToString(),
                Estado = Convert.ToBoolean(dr["estado"]),
                Id = Convert.ToInt32(dr["id"]),
                IdRol = Convert.ToInt32(dr["idRol"]),
                IdTipoDocumento = Convert.ToInt32(dr["idTipoDocumento"]),
                Nombre = dr["nombre"].ToString(),
                Telefono = dr["telefono"].ToString(),
                UsuarioSystem = dr["usuarioSystem"].ToString()
            };
        }
    }
}