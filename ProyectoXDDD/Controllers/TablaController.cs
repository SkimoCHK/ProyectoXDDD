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
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        //para mostrar editar
        public IActionResult Editar(int id)
        {
            var usuario = _usuarioDatos.ObtenerUsuario(id);
            if (usuario != null)
            {
                return View(usuario);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Editar(Usuario model)
        {
            var usuarioActualizado = _usuarioDatos.ActualizarContacto(model.IDUSUARIO, model);
            if (usuarioActualizado)
            {
                return RedirectToAction("Listar");
            }
            return View(model);
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
