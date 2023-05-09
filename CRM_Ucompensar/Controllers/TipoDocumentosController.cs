using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRM_Ucompensar.Context;
using CRM_Ucompensar.Models.Usuario;

namespace CRM_Ucompensar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoDocumentosController : ControllerBase
    {
        private readonly ConexionSQL _context;

        public TipoDocumentosController(ConexionSQL context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetTipoDocumentos")]
        // GET: TipoDocumentos
        public async Task<IActionResult> Index()
        {
              return _context.TiposDocumento != null ? 
                          Ok(await _context.TiposDocumento.ToListAsync()) :
                          Problem("Entity set 'ConexionSQL.TiposDocumento'  is null.");
        }
        [HttpGet]
        [Route("Details/{id}")]
        // GET: TipoDocumentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposDocumento == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TiposDocumento
                .FirstOrDefaultAsync(m => m.IdTipoDocumento == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return Ok(tipoDocumento);
        }

        [HttpGet]
        [Route("Create/{id}")]
        // GET: TipoDocumentos/Create
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: TipoDocumentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("IdTipoDocumento,Descripcion")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(tipoDocumento);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        // GET: TipoDocumentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposDocumento == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TiposDocumento.FindAsync(id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }
            return Ok(tipoDocumento);
        }

        // POST: TipoDocumentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoDocumento,Descripcion")] TipoDocumento tipoDocumento)
        {
            if (id != tipoDocumento.IdTipoDocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocumentoExists(tipoDocumento.IdTipoDocumento))
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
            return Ok(tipoDocumento);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        // GET: TipoDocumentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposDocumento == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TiposDocumento
                .FirstOrDefaultAsync(m => m.IdTipoDocumento == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return Ok(tipoDocumento);
        }

        // POST: TipoDocumentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposDocumento == null)
            {
                return Problem("Entity set 'ConexionSQL.TiposDocumento'  is null.");
            }
            var tipoDocumento = await _context.TiposDocumento.FindAsync(id);
            if (tipoDocumento != null)
            {
                _context.TiposDocumento.Remove(tipoDocumento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDocumentoExists(int id)
        {
          return (_context.TiposDocumento?.Any(e => e.IdTipoDocumento == id)).GetValueOrDefault();
        }
    }
}
