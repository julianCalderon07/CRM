using CRM.Entities;
using CRM.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeticionesController : ControllerBase
    {
        #region Variables de clase

        /// <summary>
        /// Objeto para servicios de peticiones
        /// </summary>
        private readonly PeticionService _peticionService = new();

        #endregion Variables de clase

        #region Servicios

        [HttpDelete]
        [HttpOptions]
        [Route("deleteRequestById")]
        public async Task<string> DeleteById(int? idPeticion)
        {
            try
            {
                await _peticionService.DeleteById(idPeticion);
                return JsonConvert.SerializeObject("OK");
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpGet]
        [HttpOptions]
        [Route("getAllRequests")]
        public async Task<string> GetAll()
        {
            try
            {
                List<Peticion> peticiones = await _peticionService.GetAll();
                return JsonConvert.SerializeObject(peticiones);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpGet]
        [HttpOptions]
        [Route("getRequestById")]
        public async Task<string> GetById(int? id)
        {
            try
            {
                Peticion peticion = await _peticionService.GetById(id);
                return JsonConvert.SerializeObject(peticion);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("saveRequest")]
        public async Task<string> Save(Peticion peticion)
        {
            try
            {
                await _peticionService.Save(peticion);
                return JsonConvert.SerializeObject("OK");
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("saveRequestById")]
        public async Task<string> SaveById(Peticion peticion)
        {
            try
            {
                await _peticionService.SaveById(peticion);
                return JsonConvert.SerializeObject("OK");
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        #endregion Servicios
    }
}