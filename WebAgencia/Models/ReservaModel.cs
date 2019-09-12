using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAgencia.Models
{
    public class ReservaModel
    {
        public int IdReserva { get; set; }
        public int IdViajero { get; set; }
        public int IdDestino { get; set; }

        [Required]
        [Display(Name = "Destino")]
        public int PlazasReserva { get; set; }

        [Display(Name = "Lugar de Origen")]
        public string LugarOrigen { get; set; }

        [Display(Name = "Fecha de Reservación")]
        public Nullable<System.DateTime> FechaReserva { get; set; }
    }
}