using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeHagoLaFila.Data;
using TeHagoLaFila.Models;

namespace TeHagoLaFila.Controllers
{
    
    public class CategoriaNegocioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaNegocioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaNegocio

        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaNegocio.ToListAsync());
        }

        // GET: CategoriaNegocio/Details/5
        [Authorize(Roles = "PowerUser")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaNegocio = await _context.CategoriaNegocio
                .SingleOrDefaultAsync(m => m.CategoriaNegocioID == id);
            if (categoriaNegocio == null)
            {
                return NotFound();
            }

            return View(categoriaNegocio);
        }

        // GET: CategoriaNegocio/Create
        [Authorize(Roles = "PowerUser")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaNegocio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaNegocioID,Nombre,Descripcion")] CategoriaNegocio categoriaNegocio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaNegocio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaNegocio);
        }

        // GET: CategoriaNegocio/Edit/5
        [Authorize(Roles = "PowerUser")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaNegocio = await _context.CategoriaNegocio.SingleOrDefaultAsync(m => m.CategoriaNegocioID == id);
            if (categoriaNegocio == null)
            {
                return NotFound();
            }
            return View(categoriaNegocio);
        }

        // POST: CategoriaNegocio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PowerUser")]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaNegocioID,Nombre,Descripcion")] CategoriaNegocio categoriaNegocio)
        {
            if (id != categoriaNegocio.CategoriaNegocioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaNegocio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaNegocioExists(categoriaNegocio.CategoriaNegocioID))
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
            return View(categoriaNegocio);
        }

        // GET: CategoriaNegocio/Delete/5
        [Authorize(Roles = "PowerUser")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaNegocio = await _context.CategoriaNegocio
                .SingleOrDefaultAsync(m => m.CategoriaNegocioID == id);
            if (categoriaNegocio == null)
            {
                return NotFound();
            }

            return View(categoriaNegocio);
        }

        // POST: CategoriaNegocio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "PowerUser")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaNegocio = await _context.CategoriaNegocio.SingleOrDefaultAsync(m => m.CategoriaNegocioID == id);
            _context.CategoriaNegocio.Remove(categoriaNegocio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaNegocioExists(int id)
        {
            return _context.CategoriaNegocio.Any(e => e.CategoriaNegocioID == id);
        }
    }
}
