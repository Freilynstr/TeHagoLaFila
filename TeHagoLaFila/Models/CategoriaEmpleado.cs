using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeHagoLaFila.Models
{
    public class CategoriaEmpleado
    {
        public int CategoriaEmpleadoID { get; set; }

        [Required(ErrorMessage = "La categoría debe tener un nombre.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La categoría debe tener una descripción.")]
        [StringLength(256, MinimumLength = 2, ErrorMessage = "La descripción debe tener entre 2 y 256 caracteres.")]
        public string Descripcion { get; set; }
    }
}
