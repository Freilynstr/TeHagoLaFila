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
        public Usuario UsuarioID { get; set; }

        [Required(ErrorMessage = "El campo empleado no debe estar en blanco ")]
        public Empleado EmpleadoID { get; set; }

        public DateTime InitialTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
