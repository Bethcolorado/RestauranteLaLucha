using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaLucha.Models
{
    public class ProductoCLS
    {
        [Display(Name ="ID")]
        public int id { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Tipo de Producto")]
        public int idTipoProducto { get; set; }
        [Display(Name = "Precio")]
        public decimal precio { get; set; }
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }
        [Display(Name ="Imagen")]
        public string imagen { get; set; }
    }
}