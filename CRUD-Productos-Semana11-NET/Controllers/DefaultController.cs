using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Productos_Semana11_NET.Models;
using CRUD_Productos_Semana11_NET.Repository;

namespace CRUD_Productos_Semana11_NET.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Productos()
        {
            ProductoRepository repository = new ProductoRepository();
            ModelState.Clear();
            return View(repository.GetProductos());
        }

        //ADD: Employee
        public ActionResult AgregarProducto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarProducto(Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductoRepository repo = new ProductoRepository();
                    if (repo.AgregarProducto(producto))
                    {
                        ViewBag.message = "Almacenado Correctamente";
                    }
                }
                return RedirectToAction("Productos");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult EditarProducto(int id)
        {
            ProductoRepository repo = new ProductoRepository();
            return View(repo.GetProductos().Find(producto => producto.id == id));
        }
        [HttpPost]
        public ActionResult EditarProducto(Producto obj)
        {
            try
            {
                ProductoRepository repo = new ProductoRepository();
                repo.ActualizarProducto(obj);

                return RedirectToAction("Productos");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return View();
            }
        }

        public ActionResult BorrarProducto(int id)
        {
            try
            {
                ProductoRepository repo = new ProductoRepository();
                if (repo.BorrarProducto(id))
                {
                    ViewBag.AlerMsg = "Producto Eliminado";
                }
                return RedirectToAction("Productos");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}