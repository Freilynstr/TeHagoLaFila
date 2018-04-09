using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeHagoLaFila.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }

        public Usuario UsuarioID { get; set; }

        public Negocio NegocioID { get; set; }

        public CategoriaEmpleado CategoriaEmpleadoID { get; set; }
    }
}
