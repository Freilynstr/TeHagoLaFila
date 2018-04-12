using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeHagoLaFila.Data;
using TeHagoLaFila.Models;

namespace TeHagoLaFila.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public EmpleadoController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Empleado
        public async Task<IActionResult> Index()
        {
            //Variable para cargar los datos del usuario logueado
            var User = _userManager.GetUserId(HttpContext.User);
            //Variable que me da el NegocioID de mi negocio
            int NegocioID = 0;

            var empleado = await _context.Empleado.SingleOrDefaultAsync(m => m.ApplicationUserID.Equals(User));
            NegocioID = empleado.NegocioID;
            //return Ok(NegocioID);
            return View(await _context.Empleado.Where(m => m.NegocioID == NegocioID).ToListAsync());            
        }

        // GET: Empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .SingleOrDefaultAsync(m => m.EmpleadoID == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // Empleado/Create
        public async Task<IActionResult> Create(Empleado empleado)
        {
            if (User.Identity.IsAuthenticated)
            {
                empleado.ApplicationUser = await _userManager.GetUserAsync(HttpContext.User);
                empleado.ApplicationUserID = _userManager.GetUserId(HttpContext.User);
                empleado.CategoriaEmpleadoID = 1;
                empleado.CategoriaEmpleado = await _context.CategoriaUsuario.FirstOrDefaultAsync(m => m.CategoriaEmpleadoID == empleado.CategoriaEmpleadoID);
                empleado.NegocioID = _context.Negocio.LastOrDefault().NegocioID;
                empleado.Negocio = await _context.Negocio.FirstOrDefaultAsync(m => m.NegocioID == empleado.NegocioID);

                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Desloguearme", "Account");
            }
            return NotFound();
        }

        // GET: Empleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.SingleOrDefaultAsync(m => m.EmpleadoID == id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpleadoID")] Empleado empleado)
        {
            if (id != empleado.EmpleadoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.EmpleadoID))
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
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .SingleOrDefaultAsync(m => m.EmpleadoID == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleado.SingleOrDefaultAsync(m => m.EmpleadoID == id);
            _context.Empleado.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleado.Any(e => e.EmpleadoID == id);
        }
    }
}
