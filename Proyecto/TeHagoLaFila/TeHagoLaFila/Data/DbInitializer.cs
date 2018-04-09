using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeHagoLaFila.Models;

namespace TeHagoLaFila.Data
{
    public class DbInitializer
    {
        public static void Initialize(TeHagoLaFilaContext context)
        {
            context.Database.EnsureCreated();

            //Verificamos si existen datos en la Base de Datos
            if (context.Usuario.Any())
            {
                return;
            }

            //Agregar Categorias de negocios
            var usuario = new Usuario[]
            {
                new Usuario{Nombre="Freilyn", Apellido="Tavárez", Sexo="MASCULINO", Telefono="849-262-9093", Username="FREILYNSTR", Correo="freilynstr@hotmail.es", Clave="98F1FA4EA5E65EC7340F5882AB0755A0"}
            };
            foreach (Usuario u in usuario)
            {
                context.Usuario.Add(u);
            }

            //Guardar los cambios
            context.SaveChanges();
        }
    }
}
