using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaLucha.Models
{
    public class EmpleadoCLS
    {
        [Display(Name="ID")]
        [Required]
        [StringLength(50,ErrorMessage ="La longitud máxima es 50")]
        public string id { get; set; }
        [Display(Name = "Contraseña")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud máxima es 50")]
        public string contra { get; set; }
        [Display(Name = "Tipo")]
        [Required]
        public int idTipoEmpleado { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud máxima es 50")]
        public string nombre { get; set; }
        [Display(Name = "Celular")]
        [Required]
        public int celular { get; set; }
        [Display(Name = "Correo")]
        [Required]
        [StringLength(100, ErrorMessage = "La longitud máxima es 100")]
        public string correo { get; set; }
        [Display(Name = "Dirección")]
        [Required]
        [StringLength(50, ErrorMessage = "La longitud máxima es 50")]
        public string direccion { get; set; }
        [Display(Name = "Sueldo")]
        [Required]  
        public decimal sueldo { get; set; }
    }
}