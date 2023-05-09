using CRM.Entities;
using CRM.Models;
using CRM.Utilities;
using System.Data;
using System.Runtime.InteropServices;

namespace CRM.Services
{
    public class PeticionService
    {
        #region Variables de clase

        /// <summary>
        /// Inicializacion del objeto ConnectionBD
        /// </summary>
        private readonly ConnectionDB _context = new();

        #endregion Variables de clase

        internal async Task DeleteById(int? idPeticion)
        {
            try
            {
                string querySentence = Sentences.DELETE_PETICION.Replace("@IDPETICION", idPeticion.ToString());
                await _context.ExecuteQuery(querySentence);
            }
            catch (Exception ex)
            {
                throw new ExternalException(ex.Message);
            }
        }

        internal async Task<List<Peticion>> GetAll()
        {
            try
            {
                DataTable dt;
                string querySentence = Sentences.SELECT_ALL_PETICIONES;
                dt = await _context.ExecuteQuery(querySentence);
                List<Peticion> peticiones = new();
                foreach (DataRow dr in dt.Rows)
                {
                    peticiones.Add(FillPeticionData(dr));
                }
                return peticiones;
            }
            catch (Exception ex)
            {
                throw new ExternalException(ex.Message);
            }
        }

        internal async Task<Peticion> GetById(int? idPeticion)
        {
            try
            {
                DataTable dt;
                string querySentence = Sentences.SELECT_PETICIONES_BY_IDPETICION.Replace("@IDPETICION", idPeticion.ToString());
                dt = await _context.ExecuteQuery(querySentence);
                return FillPeticionData(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new ExternalException(ex.Message);
            }
        }

        internal async Task Save(Peticion peticion)
        {
            try
            {
                string querySentence = BuildSentenceToInsertRequest(peticion);
                await _context.ExecuteQuery(querySentence);
            }
            catch (Exception ex)
            {
                throw new ExternalException(ex.Message);
            }
        }

        internal async Task SaveById(Peticion peticion)
        {
            try
            {
                string querySentence = BuildSentenceToUpdateRequest(peticion);
                await _context.ExecuteQuery(querySentence);
            }
            catch (Exception ex)
            {
                throw new ExternalException(ex.Message);
            }
        }

        private static string BuildSentenceToInsertRequest(Peticion peticion)
        {
            return Sentences.INSERT_PETICION
                .Replace("@ACTIVA", peticion.Activa.ToString())
                .Replace("@DESCRIPCION", peticion.Descripcion)
                .Replace("@FECHAPETICION", peticion.FechaPeticion.ToString())
                .Replace("@FECHARESPUESTA", peticion.FechaRespuesta.ToString())
                .Replace("@ID", peticion.Id.ToString())
                .Replace("@IDADMIN", peticion.IdAdmin.ToString())
                .Replace("@IDESTADOPETICIONES", peticion.IdEstadoPeticiones.ToString())
                .Replace("@IDPETICION", peticion.IdPeticion.ToString())
                .Replace("@IDTIPOPETICIONES", peticion.IdTipoPeticiones.ToString())
                .Replace("@IDTIPORESPUESTA", peticion.IdTipoRespuesta.ToString())
                .Replace("@RESPUESTA", peticion.Respuesta);
        }

        private static string BuildSentenceToUpdateRequest(Peticion peticion)
        {
            return Sentences.UPDATE_USUARIO
                .Replace("@ACTIVA", peticion.Activa.ToString())
                .Replace("@DESCRIPCION", peticion.Descripcion)
                .Replace("@FECHAPETICION", peticion.FechaPeticion.ToString())
                .Replace("@FECHARESPUESTA", peticion.FechaRespuesta.ToString())
                .Replace("@ID", peticion.Id.ToString())
                .Replace("@IDADMIN", peticion.IdAdmin.ToString())
                .Replace("@IDESTADOPETICIONES", peticion.IdEstadoPeticiones.ToString())
                .Replace("@IDPETICION", peticion.IdPeticion.ToString())
                .Replace("@IDTIPOPETICIONES", peticion.IdTipoPeticiones.ToString())
                .Replace("@IDTIPORESPUESTA", peticion.IdTipoRespuesta.ToString())
                .Replace("@RESPUESTA", peticion.Respuesta);
        }

        private static Peticion FillPeticionData(DataRow dr)
        {
            return new Peticion()
            {
                Activa = Convert.ToBoolean(dr["Activa"]),
                Descripcion = dr["Descripcion"].ToString(),
                FechaPeticion = Convert.ToDateTime(dr["fechaPeticion"]),
                FechaRespuesta = Convert.ToDateTime(dr["fechaRespuesta"]),
                Id = Convert.ToInt32(dr["id"]),
                IdAdmin = Convert.ToInt32(dr["idAdmin"]),
                IdEstadoPeticiones = Convert.ToInt32(dr["idEstadoPeticiones"]),
                IdPeticion = Convert.ToInt32(dr["idPeticion"]),
                IdTipoPeticiones = Convert.ToInt32(dr["idTipoPeticiones"]),
                IdTipoRespuesta = Convert.ToInt32(dr["idTipoRespuesta"]),
                Respuesta = dr["Respuesta"].ToString()
            };
        }
    }
}