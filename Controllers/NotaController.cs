using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MonolitoTaller.Models.DAO;
using MonolitoTaller.Models.Entities;

namespace MonolitoTaller.Controllers
{
    public class NotaController : Controller
    {
        private readonly NotaDAO dao;
        private readonly EstudianteDAO estudianteDAO;
        private readonly AsignaturaDAO asignaturaDAO;

        public NotaController(IConfiguration config)
        {
            dao = new NotaDAO(config);
            estudianteDAO = new EstudianteDAO(config);
            asignaturaDAO = new AsignaturaDAO(config);
        }

        public IActionResult Index()
        {
            var notas = dao.ObtenerNotasParaVista();
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
            ViewBag.Estudiantes = new SelectList(estudianteDAO.ObtenerTodos(), "Id", "Nombre");
            ViewBag.Asignaturas = new SelectList(asignaturaDAO.ObtenerTodas(), "Id", "Nombre");
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

            // Recargar dropdowns en caso de error
            ViewBag.Estudiantes = new SelectList(estudianteDAO.ObtenerTodos(), "Id", "Nombre");
            ViewBag.Asignaturas = new SelectList(asignaturaDAO.ObtenerTodas(), "Id", "Nombre");
            return View(nota);
        }

        public IActionResult Edit(int id)
        {
            var nota = dao.ObtenerPorId(id);
            if (nota == null) return NotFound();

            ViewBag.Estudiantes = new SelectList(estudianteDAO.ObtenerTodos(), "Id", "Nombre", nota.IdEstudiante);
            ViewBag.Asignaturas = new SelectList(asignaturaDAO.ObtenerTodas(), "Id", "Nombre", nota.IdAsignatura);

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

            ViewBag.Estudiantes = new SelectList(estudianteDAO.ObtenerTodos(), "Id", "Nombre", nota.IdEstudiante);
            ViewBag.Asignaturas = new SelectList(asignaturaDAO.ObtenerTodas(), "Id", "Nombre", nota.IdAsignatura);

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
