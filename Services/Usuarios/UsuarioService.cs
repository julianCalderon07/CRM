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

        internal async Task DeleteById(int? id)
        {
            try
            {
                string querySentence = Sentences.DELETE_USUARIO.Replace("@ID", id.ToString());
                await _context.ExecuteQuery(querySentence);
            }
            catch (Exception ex)
            {
                throw new ExternalException(ex.Message);
            }
        }

        internal async Task<List<Usuario>> GetAll()
        {
            try
            {
                DataTable dt;
                string querySentence = Sentences.SELECT_ALL_USUARIOS;
                dt = await _context.ExecuteQuery(querySentence);
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

        internal async Task<Usuario> GetById(int? id)
        {
            try
            {
                DataTable dt;
                string querySentence = Sentences.SELECT_USUARIO_BY_ID.Replace("@ID", id.ToString());
                dt = await _context.ExecuteQuery(querySentence);
                return FillUsuarioData(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new ExternalException(ex.Message);
            }
        }

        internal async Task Save(Usuario usuario)
        {
            try
            {
                string querySentence = BuildSentenceToInsertUser(usuario);
                await _context.ExecuteQuery(querySentence);
            }
            catch (Exception ex)
            {
                throw new ExternalException(ex.Message);
            }
        }

        internal async Task SaveById(Usuario usuario)
        {
            try
            {
                string querySentence = BuildSentenceToUpdateUser(usuario);
                await _context.ExecuteQuery(querySentence);
            }
            catch (Exception ex)
            {
                throw new ExternalException(ex.Message);
            }
        }

        private static string BuildSentenceToInsertUser(Usuario usuario)
        {
            return Sentences.INSERT_USUARIO
                .Replace("@CONTRASENA", usuario.Contrasena)
                .Replace("@CORREO", usuario.Correo)
                .Replace("@DOCUMENTO", usuario.Documento)
                .Replace("@ESTADO", usuario.Estado.ToString())
                .Replace("@IDROL", usuario.IdRol.ToString())
                .Replace("@IDTIPODOCUMENTO", usuario.IdTipoDocumento.ToString())
                .Replace("@NOMBRE", usuario.Nombre)
                .Replace("@TELEFONO", usuario.Telefono)
                .Replace("@USUARIOSYSTEM", usuario.UsuarioSystem);
        }

        private static string BuildSentenceToUpdateUser(Usuario usuario)
        {
            return Sentences.UPDATE_USUARIO
                .Replace("@CONTRASENA", usuario.Contrasena)
                .Replace("@CORREO", usuario.Correo)
                .Replace("@DOCUMENTO", usuario.Documento)
                .Replace("@ESTADO", usuario.Estado.ToString())
                .Replace("@ID", usuario.Id.ToString())
                .Replace("@IDROL", usuario.IdRol.ToString())
                .Replace("@IDTIPODOCUMENTO", usuario.IdTipoDocumento.ToString())
                .Replace("@NOMBRE", usuario.Nombre)
                .Replace("@TELEFONO", usuario.Telefono)
                .Replace("@USUARIOSYSTEM", usuario.UsuarioSystem);
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