using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeHagoLaFila.Models;

namespace TeHagoLaFila.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<TeHagoLaFila.Models.CategoriaNegocio> CategoriaNegocio { get; set; }

        public DbSet<TeHagoLaFila.Models.CategoriaEmpleado> CategoriaUsuario { get; set; }

        public DbSet<TeHagoLaFila.Models.Negocio> Negocio { get; set; }

        public DbSet<TeHagoLaFila.Models.Empleado> Empleado { get; set; }

        public DbSet<TeHagoLaFila.Models.Reservacion> Reservacion { get; set; }
    }
}
