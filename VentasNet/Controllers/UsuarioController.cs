using Microsoft.AspNetCore.Mvc;
using VentasNet.Models;
using VentasNet.Repositorio;

namespace VentasNet.Controllers
{
    public class UsuarioController : Controller
    {
        bool incorrect=false;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inicio()
        {
            ViewBag.Incorrect = incorrect;

            return View();
        }

        public IActionResult AgregarUsuario(Usuario usu) {
            return View();
        }

        public IActionResult GuardarUsuario(Usuario nextUsuario)
        {

            var index = Listados.ListadoUsuarios.FindIndex(x => x.Id == nextUsuario.Id);

            Listados.ListadoUsuarios[index].Login = nextUsuario.Login;
            Listados.ListadoUsuarios[index].Password = nextUsuario.Password;

            return RedirectToAction("Usuario", "Usuario");
        }

        public IActionResult Usuario(Usuario usuario)
        {
            //Listados.ListadoUsuarios.Where(x => x.Login == usuario.Login && x.Password == usuario.Password).FirstOrDefault();
            //Si login y contraseña son incorrectos Redirecciono
            if (usuario.Login != Listados.ListadoUsuarios[0].Login && usuario.Password != Listados.ListadoUsuarios[0].Password)
            {
                incorrect = true;
                return RedirectToAction("Inicio", "Usuario");
            }

            ////Si login y contraseña son correctos muestro Usuario
            ViewBag.Usuario = Listados.ListadoUsuarios[0];
            return View();
        }

        public IActionResult Edit(int id)
        {
            Usuario usu = new Usuario();

            usu = Listados.ListadoUsuarios.Find(x => x.Id == id);

            return RedirectToAction("AgregarUsuario", "Usuario" , usu);
        }

    }
}
