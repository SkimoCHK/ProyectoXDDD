using Microsoft.AspNetCore.Mvc;
using ProyectoXDDD.Datos;
using ProyectoXDDD.Models;

namespace ProyectoXDDD.Controllers
{
    public class TablaController : Controller
    {
        UsuarioDatos _usuarioDatos = new UsuarioDatos();
        public IActionResult Listar()
        {
            var lista = _usuarioDatos.Listar();
            return View(lista);
        }
        //para mostrar guardar
        public IActionResult Guardar()
        {
            return View();
        }

        //para guardar
        [HttpPost]
        public IActionResult Guardar(Usuario model)
        {
            var usuarioCreado = _usuarioDatos.GuardarContacto(model);
            if (usuarioCreado)
            {
                return RedirectToAction("Guardar");
            }
            else
            {
                return View();
            }
        }

        //para mostrar editar
        public IActionResult Editar()
        {
            return View();
        }

        //para editar
        [HttpPost]
        public IActionResult Editar(Usuario model)
        {
            return View();
        }

        //para mostrar eliminar
        public IActionResult Eliminar()
        {
            return View();
        }

        //para eliminar
        [HttpPost]
        public IActionResult Eliminar(int IDUSUARIO)
        {
            return View();
        }
    }
}
