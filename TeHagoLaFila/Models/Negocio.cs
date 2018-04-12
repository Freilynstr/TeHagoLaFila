using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeHagoLaFila.Models
{
    public class Negocio
    {
        public int NegocioID { get; set; }

        [Required(ErrorMessage = "El negocio debe tener un nombre.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El negocio debe tener una descripción.")]
        [StringLength(256, MinimumLength = 2, ErrorMessage = "La descripción debe tener entre 2 y 256 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Cada negocio tiene una categoría")]
        [Display(Name = "Tipo de Negocio")]
        public int CategoriaNegocioID { get; set; }

        [Required(ErrorMessage = "Escriba la dirección del negocio")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        public ICollection<Empleado> Empleado { get; set; }

        public CategoriaNegocio CategoriaNegocio { get; set; }
    }
}
