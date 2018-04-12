using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TeHagoLaFila.Models
{
    public class Usuario
    {

        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "El usuario debe tener un nombre.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El usuario debe tener un apellido.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El usuario debe tener un sexo.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El sexo debe ser válido.")]
        public string Sexo { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "El teléfono debe tener entre 10 y 20 caracteres.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe establecer un usuario.")]
        //[Index(IsUnique=true)]
        [Remote("UsernameExist", "Usuario", HttpMethod = "POST", ErrorMessage = "Este usuario ya existe")]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Debe tener un correo electrónico.")]
        [EmailAddress]
        [Remote("ExisteCorreo", "Usuario", HttpMethod = "POST", ErrorMessage = "Este correo ya esta registrado.")]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [Display(Name = "Contraseña")]
        public string Clave { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Clave", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmarClave { get; set; }

        public byte[] Image { get; set; }
    }
}
