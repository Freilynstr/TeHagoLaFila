using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeHagoLaFila.Data;
using TeHagoLaFila.Models;

namespace TeHagoLaFila.Controllers
{
    public class CategoriaEmpleadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaEmpleadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaEmpleado
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaUsuario.ToListAsync());
        }

        // GET: CategoriaEmpleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaEmpleado = await _context.CategoriaUsuario
                .SingleOrDefaultAsync(m => m.CategoriaEmpleadoID == id);
            if (categoriaEmpleado == null)
            {
                return NotFound();
            }

            return View(categoriaEmpleado);
        }

        // GET: CategoriaEmpleado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaEmpleado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaEmpleadoID,Nombre,Descripcion")] CategoriaEmpleado categoriaEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaEmpleado);
        }

        // GET: CategoriaEmpleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaEmpleado = await _context.CategoriaUsuario.SingleOrDefaultAsync(m => m.CategoriaEmpleadoID == id);
            if (categoriaEmpleado == null)
            {
                return NotFound();
            }
            return View(categoriaEmpleado);
        }

        // POST: CategoriaEmpleado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaEmpleadoID,Nombre,Descripcion")] CategoriaEmpleado categoriaEmpleado)
        {
            if (id != categoriaEmpleado.CategoriaEmpleadoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaEmpleadoExists(categoriaEmpleado.CategoriaEmpleadoID))
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
            return View(categoriaEmpleado);
        }

        // GET: CategoriaEmpleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaEmpleado = await _context.CategoriaUsuario
                .SingleOrDefaultAsync(m => m.CategoriaEmpleadoID == id);
            if (categoriaEmpleado == null)
            {
                return NotFound();
            }

            return View(categoriaEmpleado);
        }

        // POST: CategoriaEmpleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaEmpleado = await _context.CategoriaUsuario.SingleOrDefaultAsync(m => m.CategoriaEmpleadoID == id);
            _context.CategoriaUsuario.Remove(categoriaEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaEmpleadoExists(int id)
        {
            return _context.CategoriaUsuario.Any(e => e.CategoriaEmpleadoID == id);
        }
    }
}
