using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaLucha.Models;

namespace LaLucha.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<ProductoCLS> listaProducto = null;

            using (var bd = new RestauranteEntities()) 
            {
                listaProducto = (from producto in bd.Producto
                                select new ProductoCLS
                                {
                                    id = producto.ID,
                                    nombre = producto.Nombre,
                                    idTipoProducto = producto.IdTipoProducto,
                                    precio = producto.Precio,
                                    descripcion = producto.Descripcion,
                                    imagen = producto.imagen
                                }).ToList();
            }
            
            return View(listaProducto);
        }
    }
}