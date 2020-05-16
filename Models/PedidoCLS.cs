using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaLucha.Models
{
    public class PedidoCLS
    {
        [Display(Name="ID")]
        public int id { get; set; }
        [Display(Name = "Atendido")]
        public bool atendido { get; set; }
        [Display(Name = "Detalle")]
        public string detalle { get; set; }
        [Display(Name = "ID Empleado")]
        public string idEmpleado { get; set; }
    }
}