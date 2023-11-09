using Microsoft.AspNetCore.Mvc;
using VentasNet.Models;
using VentasNet.Repositorio;

namespace VentasNet.Controllers
{
    public class ProveedorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listado() 
        {
            ViewBag.Proveedor = Listados.ListadoProveedor.Where(x => x.Estado == true);

            return View();
        }

        public IActionResult Create(Proveedor prov) //agregar proveedor
        {
            return View();
        }

        public IActionResult GuardarProveedor(Proveedor nextProveedor) 
        {
            if (nextProveedor.Estado == true)
            {
                ProveedorRepo.ModificarProveedor(nextProveedor);
            }
            else
            {
                bool existe = ProveedorRepo.VerificarProveedor(nextProveedor);

                if (existe)
                {
                    ProveedorRepo.ModificarId(nextProveedor);
                }
                else
                {
                    nextProveedor.Estado = true;
                    Listados.ListadoProveedor.Add(nextProveedor);
                } 
            }

            return RedirectToAction("Listado", "Proveedor");
        }

        public IActionResult Edit(int id)
        {
            Proveedor prov = new Proveedor();

            prov = Listados.ListadoProveedor.Find(x => x.Id == id);

            return RedirectToAction("Create", "Proveedor", prov);
        }

        public IActionResult Delete(int id)
        {
            Proveedor? prov = new Proveedor();
            prov = Listados.ListadoProveedor.Find(x => x.Id == id);

            if (prov != null)
            Listados.ListadoProveedor.Remove(prov);
    
            return RedirectToAction("Listado", "Proveedor");
        }


    }
}
