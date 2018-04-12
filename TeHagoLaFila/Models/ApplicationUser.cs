using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TeHagoLaFila.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //[Required]
        public string Name { get; set; }

        //[Required]
        public string LastName { get; set; }
        
        //[Required]
        public string Gender { get; set; }

        public byte[] Image { get; set; }

        public ICollection<Empleado> Empleado { get; set; }
    }
}
