using Microsoft.AspNetCore.Mvc;
using VentasNet.Models;
using VentasNet.Repositorio;

namespace VentasNet.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListadoProducto()
        {
            ViewBag.ProdDisponible = Listados.ListadoProducto;

            return View();
        }

        public IActionResult AgregarProducto(Producto prod)
        {

            return View();
        }

        public IActionResult GuardarProducto(Producto nextProducto)
        {
            Producto prod = new Producto();

            var index = Listados.ListadoProducto.FindIndex(x => x.Id == nextProducto.Id);

            Listados.ListadoProducto[index].Id = nextProducto.Id;
            Listados.ListadoProducto[index].IdProveedor = nextProducto.IdProveedor;
            Listados.ListadoProducto[index].NombreProducto = nextProducto.NombreProducto;
            Listados.ListadoProducto[index].Descripcion = nextProducto.Descripcion;
            Listados.ListadoProducto[index].ImporteProducto = nextProducto.ImporteProducto;

            return RedirectToAction("ListadoProducto", "Producto");
        }

        public IActionResult Edit(int id)
        {
            Producto prod = new Producto(); 

            prod = Listados.ListadoProducto.Find(x => x.Id == id);

            return RedirectToAction("AgregarProducto", prod);
        }

        public IActionResult Delete(int id)
        {
            Producto prod = new Producto();

            prod = Listados.ListadoProducto.Find(x => x.Id == id);

            Listados.ListadoProducto.Remove(prod);

            return RedirectToAction("ListadoProducto", "Producto");

        }
    }
}
