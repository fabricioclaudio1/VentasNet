using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using VentasNet.Models;
using VentasNet.Repositorio;

namespace VentasNet.Controllers
{
    public class ClienteController : Controller
    {
        ClienteRepo clienteRepo = new ClienteRepo();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listado()
        {
            ViewBag.Cliente = Listados.ListadoClientes.Where(x => x.Estado == true);

            return View();

        }
        public IActionResult AgregarCliente(Cliente cli)
        { 
            return View();
        }

        //[HttpPost]
        public IActionResult GuardarCliente(Cliente nextCliente)
        {
            bool existe = false;

            Cliente existeCliente= new Cliente(); //En que momento se usa?
            existe = clienteRepo.VerificarCliente(nextCliente);

            if (existe)
            {
                clienteRepo.ModificarCliente(nextCliente); //'ModificarCliente' solo le da un nuevo id a 'nextCliente' que no esté en uso.
            }
            else
            {
                nextCliente.Estado = true;
                Listados.ListadoClientes.Add(nextCliente);
            }
            return RedirectToAction("Listado");
        }

        public IActionResult Edit(int id)
        {
            Cliente cli = new Cliente();

            cli = Listados.ListadoClientes.Find(x => x.Id == id);

            return RedirectToAction("AgregarCliente", cli);
        }
        public IActionResult Delete(int id)
        {
            Cliente cli = new Cliente();

            cli = Listados.ListadoClientes.Find(x => x.Id == id);

            Listados.ListadoClientes.Remove(cli);

            return RedirectToAction("Listado");
        }
    }
}
