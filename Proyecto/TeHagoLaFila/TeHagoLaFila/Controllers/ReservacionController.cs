using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeHagoLaFila.Models;

namespace TeHagoLaFila.Controllers
{
    public class ReservacionController : Controller
    {
        private readonly TeHagoLaFilaContext _context;

        public ReservacionController(TeHagoLaFilaContext context)
        {
            _context = context;
        }

        // GET: Reservacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservacion.ToListAsync());
        }

        // GET: Reservacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacion
                .SingleOrDefaultAsync(m => m.ReservacionID == id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        // GET: Reservacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservacionID,InitialTime,EndTime")] Reservacion reservacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservacion);
        }

        // GET: Reservacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacion.SingleOrDefaultAsync(m => m.ReservacionID == id);
            if (reservacion == null)
            {
                return NotFound();
            }
            return View(reservacion);
        }

        // POST: Reservacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservacionID,InitialTime,EndTime")] Reservacion reservacion)
        {
            if (id != reservacion.ReservacionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservacionExists(reservacion.ReservacionID))
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
            return View(reservacion);
        }

        // GET: Reservacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservacion = await _context.Reservacion
                .SingleOrDefaultAsync(m => m.ReservacionID == id);
            if (reservacion == null)
            {
                return NotFound();
            }

            return View(reservacion);
        }

        // POST: Reservacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservacion = await _context.Reservacion.SingleOrDefaultAsync(m => m.ReservacionID == id);
            _context.Reservacion.Remove(reservacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservacionExists(int id)
        {
            return _context.Reservacion.Any(e => e.ReservacionID == id);
        }
    }
}
