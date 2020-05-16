using LaLucha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;


namespace LaLucha.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        
        List<SelectListItem> listCombo;
        List<SelectListItem> listHamburguesa;
        List<SelectListItem> listComplementos;
        List<ProductoCLS> listaPedido = new List<ProductoCLS>();

        public ActionResult Index()
        {
            List<PedidoCLS> listaPedidos = null;

            using (var bd = new RestauranteEntities())
            {
                listaPedidos = (from pedido in bd.Pedido
                                where pedido.Atendido == false
                                select new PedidoCLS
                                {
                                    id = pedido.ID,
                                    atendido = pedido.Atendido,
                                    detalle = pedido.Detalle,
                                    idEmpleado = pedido.IdEmpleado
                                }
                                ).ToList();
            }

            return View(listaPedidos);
        }

        private void ListHamb()
        {
            using (var bd = new RestauranteEntities())
            {
                listHamburguesa = (from hamb in bd.Producto
                                   where hamb.Descripcion.ToLower().StartsWith("hamburguesa")
                                   select new SelectListItem
                                   {
                                       Text = hamb.Nombre,
                                       Value = hamb.ID.ToString(),
                                       Selected = false
                                   }).ToList();
            }
        }

        private void ListComplementos()
        {
            using (var bd = new RestauranteEntities())
            {
                listComplementos = (from hamb in bd.Producto
                                   where !hamb.Descripcion.ToLower().StartsWith("combo") && !hamb.Descripcion.ToLower().Contains("hamburguesa")
                                   select new SelectListItem
                                   {
                                       Text = hamb.Nombre,
                                       Value = hamb.ID.ToString(),
                                       Selected = false
                                   }).ToList();
            }
        }

        private void ListCombo()
        {
            using (var bd = new RestauranteEntities())
            {
                listCombo = (from hamb in bd.Producto
                                   where hamb.Descripcion.ToLower().StartsWith("combo") || hamb.Descripcion.ToLower().Contains("hamburguesas")
                                   select new SelectListItem
                                   {
                                       Text = hamb.Nombre,
                                       Value = hamb.ID.ToString(),
                                       Selected = false
                                   }).ToList();
            }
        }


        public ActionResult Agregar()
        {
            ListHamb();ListCombo();ListComplementos();

            ViewBag.listCombo = listCombo;
            ViewBag.listHamb = listHamburguesa;
            ViewBag.listComp = listComplementos;

            return View();
        }

        [HttpPost]
        public ActionResult Agregar(ProductoCLS productoCLS)
        {
            ListHamb();ListCombo();ListComplementos();

            ViewBag.listCombo = listCombo;
            ViewBag.listHamb = listHamburguesa;
            ViewBag.listComp = listComplementos;

            List<ProductoCLS> listaTemporal = null;

            using (var bd = new RestauranteEntities())
            {
                listaTemporal = (from producto in bd.Producto
                                where producto.ID == productoCLS.id
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

            listaPedido.Add(listaTemporal.ElementAt(0));

            ViewBag.listaPedidos = listaPedido;

            return View();
        }
    }
}