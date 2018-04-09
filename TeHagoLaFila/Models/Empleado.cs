using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeHagoLaFila.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string ApplicationUserID { get; set; }

        [Required]
        [Display(Name = "Negocio")]
        public int NegocioID { get; set; }

        [Required]
        [Display(Name = "Tipo de Empleado")]
        public int CategoriaEmpleadoID { get; set; }

        public Negocio Negocio { get; set; }
        public CategoriaEmpleado CategoriaEmpleado { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
