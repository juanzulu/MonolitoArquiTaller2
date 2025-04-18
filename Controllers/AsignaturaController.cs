using Microsoft.AspNetCore.Mvc;
using MonolitoTaller.Models.DAO;
using MonolitoTaller.Models.Entities;

namespace MonolitoTaller.Controllers
{
    public class AsignaturaController : Controller
    {
        private readonly AsignaturaDAO dao;

        public AsignaturaController(IConfiguration config)
        {
            dao = new AsignaturaDAO(config);
        }

        public IActionResult Index()
        {
            var asignaturas = dao.ObtenerTodas();
            return View(asignaturas);
        }

        public IActionResult Details(int id)
        {
            var asignatura = dao.ObtenerPorId(id);
            if (asignatura == null) return NotFound();
            return View(asignatura);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                dao.Crear(asignatura);
                return RedirectToAction(nameof(Index));
            }
            return View(asignatura);
        }

        public IActionResult Edit(int id)
        {
            var asignatura = dao.ObtenerPorId(id);
            if (asignatura == null) return NotFound();
            return View(asignatura);
        }

        [HttpPost]
        public IActionResult Edit(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                dao.Actualizar(asignatura);
                return RedirectToAction(nameof(Index));
            }
            return View(asignatura);
        }

        public IActionResult Delete(int id)
        {
            var asignatura = dao.ObtenerPorId(id);
            if (asignatura == null) return NotFound();
            return View(asignatura);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            dao.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
