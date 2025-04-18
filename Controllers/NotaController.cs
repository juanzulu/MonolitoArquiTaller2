using Microsoft.AspNetCore.Mvc;
using MonolitoTaller.Models.DAO;
using MonolitoTaller.Models.Entities;

namespace MonolitoTaller.Controllers
{
    public class NotaController : Controller
    {
        private readonly NotaDAO dao;

        public NotaController(IConfiguration config)
        {
            dao = new NotaDAO(config);
        }

        public IActionResult Index()
        {
            var notas = dao.ObtenerTodas();
            return View(notas);
        }

        public IActionResult Details(int id)
        {
            var nota = dao.ObtenerPorId(id);
            if (nota == null) return NotFound();
            return View(nota);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Nota nota)
        {
            if (ModelState.IsValid)
            {
                dao.Crear(nota);
                return RedirectToAction(nameof(Index));
            }
            return View(nota);
        }

        public IActionResult Edit(int id)
        {
            var nota = dao.ObtenerPorId(id);
            if (nota == null) return NotFound();
            return View(nota);
        }

        [HttpPost]
        public IActionResult Edit(Nota nota)
        {
            if (ModelState.IsValid)
            {
                dao.Actualizar(nota);
                return RedirectToAction(nameof(Index));
            }
            return View(nota);
        }

        public IActionResult Delete(int id)
        {
            var nota = dao.ObtenerPorId(id);
            if (nota == null) return NotFound();
            return View(nota);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            dao.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
