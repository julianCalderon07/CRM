using CRM.Entities;
using CRM.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        #region Variables de clase

        /// <summary>
        ///
        /// </summary>
        private readonly UsuarioService _usuarioService = new();

        #endregion Variables de clase

        #region Servicios

        [HttpDelete]
        [HttpOptions]
        [Route("deleteUserById")]
        public async Task<string> DeleteById(int? id)
        {
            try
            {
                await _usuarioService.DeleteById(id);
                return JsonConvert.SerializeObject("OK");
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpGet]
        [HttpOptions]
        [Route("getAllUsers")]
        public async Task<string> GetAll()
        {
            try
            {
                List<Usuario> usuarios = await _usuarioService.GetAll();
                return JsonConvert.SerializeObject(usuarios);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpGet]
        [HttpOptions]
        [Route("getUserById")]
        public async Task<string> GetById(int? id)
        {
            try
            {
                Usuario usuario = await _usuarioService.GetById(id);
                return JsonConvert.SerializeObject(usuario);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("saveUser")]
        public async Task<string> Save(Usuario usuario)
        {
            try
            {
                await _usuarioService.Save(usuario);
                return JsonConvert.SerializeObject("OK");
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        [HttpPost]
        [HttpOptions]
        [Route("saveUserById")]
        public async Task<string> SaveById(Usuario usuario)
        {
            try
            {
                await _usuarioService.SaveById(usuario);
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