using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Repositories;
using VentasNet.Models;

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
            ViewBag.Cliente = clienteRepo.GetClientes();

            return View();

        }
        public IActionResult AgregarCliente(ClienteReq cli)
        {
            var result= clienteRepo.AddCliente(cli);

            return View();
        }

        //[HttpPost]
        public IActionResult GuardarCliente(ClienteReq nextCliente)
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

        public IActionResult Edit(ClienteReq cli)
        {
            var result = clienteRepo.UpdateCliente(cli);

            //Cliente cli = new Cliente();

            //cli = Listados.ListadoClientes.Find(x => x.Id == id);

            return RedirectToAction("AgregarCliente", cli);
        }
        public IActionResult Delete(ClienteReq cli)
        {
            var clienteResponse = clienteRepo.Delete(cli);

            //Cliente cli = new Cliente();

            //cli = Listados.ListadoClientes.Find(x => x.Id == id);

            //Listados.ListadoClientes.Remove(cli);

            return RedirectToAction("Listado");
        }
    }
}
