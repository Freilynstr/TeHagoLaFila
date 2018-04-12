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
    [Authorize]
    public class NegocioController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public NegocioController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }

        // GET: Negocio
        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            
           
            var negocio = await _context.Negocio.Where(m => m.CategoriaNegocioID == id).ToListAsync();
            if (negocio == null)
            {
                throw new ApplicationException($"Unable to load Bussiness.");
            }
            return View(negocio);
        }

        // GET: Negocio/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //Obteniendo el Negocio seleccionado
            var negocio = await _context.Negocio
                .FirstOrDefaultAsync(m => m.NegocioID == id);
            if (negocio == null)
            {
                return NotFound();
            }

            //Obteniendo los empleados del Negocio seleccionado
            ViewBag.empleados = await _context.Empleado.Where(m => m.NegocioID == negocio.NegocioID).ToListAsync();
   
            if(ViewBag.empleados == null)
            {
                return NotFound();
            }
            
            //Obteniendo las reservaciones en el Negocio seleccionado
            ViewBag.reservaciones = await _context.Reservacion.Where(m => m.Empleado.NegocioID  == negocio.NegocioID).ToListAsync();

            //Obteniendo los datos del usuario logueado
            ViewBag.usuario = await _userManager.GetUserAsync(User);

            return View(negocio);
        }

        // GET: Negocio/Create
        public IActionResult Create()
        {
            List<CategoriaNegocio> categoriasList = new List<CategoriaNegocio>();

            categoriasList = (from product in _context.CategoriaNegocio
                              select product).ToList();

            categoriasList.Insert(0, new CategoriaNegocio { CategoriaNegocioID = 0, Nombre = "Select", Descripcion = "No descripcion"});

            ViewBag.ListOfCategories = categoriasList;
            return View();
        }

        // POST: Negocio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Negocio model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                
                var negocio = new Negocio {
                    Nombre = model.Nombre,
                    Descripcion = model.Descripcion,
                    Direccion = model.Direccion,
                    CategoriaNegocioID = model.CategoriaNegocioID
                };
                _context.Add(negocio);
                await _context.SaveChangesAsync();

                if (User.Identity.IsAuthenticated)
                {
                    await _roleManager.CreateAsync(new IdentityRole("Administrador"));
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    await _userManager.AddToRoleAsync(user, "Administrador");
                }
                return RedirectToAction("Create", "Empleado");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NegocioID,Nombre,Descripcion,Direccion")] Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(negocio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(negocio);
        }*/

        // GET: Negocio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negocio = await _context.Negocio.SingleOrDefaultAsync(m => m.NegocioID == id);
            if (negocio == null)
            {
                return NotFound();
            }
            return View(negocio);
        }

        // POST: Negocio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NegocioID,Nombre,Descripcion,Direccion")] Negocio negocio)
        {
            if (id != negocio.NegocioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(negocio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NegocioExists(negocio.NegocioID))
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
            return View(negocio);
        }

        // GET: Negocio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negocio = await _context.Negocio
                .SingleOrDefaultAsync(m => m.NegocioID == id);
            if (negocio == null)
            {
                return NotFound();
            }

            return View(negocio);
        }

        // POST: Negocio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var negocio = await _context.Negocio.SingleOrDefaultAsync(m => m.NegocioID == id);
            _context.Negocio.Remove(negocio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NegocioExists(int id)
        {
            return _context.Negocio.Any(e => e.NegocioID == id);
        }

        public async Task<IActionResult> ListarNegocios()
        {
            var negociosList = "";

            return Ok(negociosList);



            //return _context.Negocio)
        }
    }
}
