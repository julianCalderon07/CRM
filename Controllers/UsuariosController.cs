using CRM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Newtonsoft.Json;
using CRM.Services;
using CRM.Entities;

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

        [HttpGet]
        [HttpOptions]
        [Route("getAllUsers")]
        public string GetAll()
        {
            try
            {
                List<Usuario> usuarios = _usuarioService.GetAll();
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
        public string GetById(int? id)
        {
            try
            {
                Usuario usuario = _usuarioService.GetById(id);
                return JsonConvert.SerializeObject(usuario);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(ex.Message);
            }
        }

        #endregion Servicios
    }
}