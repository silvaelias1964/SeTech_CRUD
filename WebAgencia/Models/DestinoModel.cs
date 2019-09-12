using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAgencia.Models
{
    public class DestinoModel
    {
        public int IdDestino { get; set; }

        [Required(ErrorMessage = "Introduce el destino"), MaxLength(50)]
        [Display(Name = "Destino")]
        public string Destino { get; set; }

        [Required]
        [Display(Name = "Precio")]
        //[DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal Precio { get; set; }

        [Required]
        [Display(Name = "Plazas")]
        public int Plazas { get; set; }
    }
}