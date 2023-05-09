using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM_Ucompensar.Context;
using CRM_Ucompensar.Models.usuario;
using CRM_Ucompensar.Models.Usuario;

namespace CRM_Ucompensar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ConexionSQL _context;

        public UsuariosController(ConexionSQL context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetUsuarios")]
        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
           var query = from u in _context.Usuarios
                        join td in _context.TiposDocumento on u.IdTipoDocumento equals td.IdTipoDocumento
                        join r in _context.Rols on u.IdRol equals r.IdRol
                        select new UsuarioInfo
                        {
                            Usuario = u,
                            Rol = r,
                            TipoDocumento = td
                        };
            var x = query.ToList();
            return _context.Usuarios != null ? 
                          Ok(await _context.Usuarios.ToListAsync()) :
                          Problem("Entity set 'ConexionSQL.Usuarios'  is null.");
        }

        [HttpGet]
        [Route("Details/{id}")]
        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpGet]
        [Route("Create/{id}")]
        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("Id,Nombre,IdRol,Estado,Documento,IdTipoDocumento,Telefono,Correo,UsuarioSystem,password")] Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(usuario);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,IdRol,Estado,Documento,IdTipoDocumento,Telefono,Correo,UsuarioSystem,password")] Usuarios usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return Ok(usuario);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'ConexionSQL.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("ValidateUser")]
        public async Task<IActionResult> ValidateUser(string? user,string? password) {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'ConexionSQL.Usuarios'  is null.");
            }
            var usuario =  await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioSystem == user && m.contrasena==password);

            if (usuario == null)
            {
                return Ok(usuario);
            }

            return Ok(usuario);


        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
