using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAgencia.Models
{
    public class ViajeroModel
    {
        [Display(Name = "Código")]
        public int IdViajero { get; set; }

        [Required(ErrorMessage = "Introduce la Cédula o Pasaporte de la persona"), MaxLength(20)]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Introduce el Nombre de la persona"), MaxLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Introduce el Apellido de la persona"), MaxLength(50)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(200)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Introduce los teléfonos"), MaxLength(50)]
        [Display(Name = "Teléfonos")]
        [StringLength(50)]
        public string Telefonos { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Por favor introduzca un Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "El Email no es valido!")]
        public string CorreoE { get; set; }
    }
}