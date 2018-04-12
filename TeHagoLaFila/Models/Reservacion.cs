using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeHagoLaFila.Models
{
    public class Reservacion
    {
        public int ReservacionID { get; set; }

        [Required(ErrorMessage = "El campo usuario no debe estar en blanco")]
        [Display(Name = "Usuario")]
        public string ApplicationUserID { get; set; }

        [Required(ErrorMessage = "El campo negocio no debe estar en blanco")]
        [Display(Name = "Empleado")]
        public int EmpleadoID { get; set; }

        public DateTime? InitialReservationTime { get; set; }

        public DateTime? InitialServiceTime { get; set; }

        public DateTime? EndAllTimes { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Empleado Empleado { get; set; }
    }
}
