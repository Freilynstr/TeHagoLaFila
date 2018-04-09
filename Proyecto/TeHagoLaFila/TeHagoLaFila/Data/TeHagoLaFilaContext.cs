using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeHagoLaFila.Models;

namespace TeHagoLaFila.Models
{
    public class TeHagoLaFilaContext : DbContext
    {
        public TeHagoLaFilaContext (DbContextOptions<TeHagoLaFilaContext> options)
            : base(options)
        {
        }

        public DbSet<TeHagoLaFila.Models.Usuario> Usuario { get; set; }

        public DbSet<TeHagoLaFila.Models.CategoriaEmpleado> CategoriaEmpleado { get; set; }

        public DbSet<TeHagoLaFila.Models.CategoriaNegocio> CategoriaNegocio { get; set; }

        public DbSet<TeHagoLaFila.Models.Negocio> Negocio { get; set; }

        public DbSet<TeHagoLaFila.Models.Empleado> Empleado { get; set; }

        public DbSet<TeHagoLaFila.Models.Reservacion> Reservacion { get; set; }
    }
}
