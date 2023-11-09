using Microsoft.AspNetCore.Mvc;
using VentasNet.Models;

namespace VentasNet.Controllers
{
    public class VentaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListadoVenta()
        {
            ViewBag.Venta = Listados.ListadoVenta;
            return View();
        }

        public IActionResult ListadoProductoVendido()
        {
            ViewBag.ProdVendido = Listados.ListadoProductoVendido;
            return View();
        }
    }
}
