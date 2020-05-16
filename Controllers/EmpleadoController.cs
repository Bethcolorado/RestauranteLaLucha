using LaLucha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaLucha.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {

            List<EmpleadoCLS> listaEmpleados = null;

            using (var bd = new RestauranteEntities())
            {
                listaEmpleados = (from empleado in bd.Empleado
                                  select new EmpleadoCLS
                                  {
                                      id = empleado.ID,
                                      idTipoEmpleado = empleado.IdTipoEmpleado,
                                      nombre = empleado.Nombre,
                                      celular = empleado.Celular,
                                      correo = empleado.Correo,
                                      direccion = empleado.Direccion,
                                      sueldo = empleado.Sueldo
                                  }).ToList();
            }
            
            return View(listaEmpleados);
        }

        public ActionResult Agregar()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Agregar(EmpleadoCLS oEmpleadoCLS)
        {
            if(!ModelState.IsValid)
            {
                return View(oEmpleadoCLS);
            }else
            {
                using (var bd = new RestauranteEntities())
                {
                    Empleado oEmpleado = new Empleado();
                    oEmpleado.ID = oEmpleadoCLS.id;
                    oEmpleado.Nombre = oEmpleadoCLS.nombre;
                    oEmpleado.IdTipoEmpleado = oEmpleadoCLS.idTipoEmpleado;
                    oEmpleado.Celular = oEmpleadoCLS.celular;
                    oEmpleado.Contraseña = oEmpleadoCLS.contra;
                    oEmpleado.Correo = oEmpleadoCLS.correo;
                    oEmpleado.Direccion = oEmpleadoCLS.direccion;
                    oEmpleado.Sueldo = oEmpleadoCLS.sueldo;
                    bd.Empleado.Add(oEmpleado);
                    bd.SaveChanges();
                }

            }

            
            
            
            return RedirectToAction("Index");
        }
    }
}