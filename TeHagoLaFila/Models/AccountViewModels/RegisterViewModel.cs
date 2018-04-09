using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeHagoLaFila.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(32, ErrorMessage = "El usuario debe tener un nombre válido (entre 2 y 32 caracteres).", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "El usuario debe tener un apellido válido (entre 2 y 32 caracteres).", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "El usuario debe tener un género válido (entre 2 y 32 caracteres).", MinimumLength = 2)]
        public string Gender { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "El usuario debe tener un nombre de usuario válido (entre 2 y 32 caracteres).", MinimumLength = 2)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Remote("EmailExists", "Account", HttpMethod = "POST", ErrorMessage = "Email address already registered.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
