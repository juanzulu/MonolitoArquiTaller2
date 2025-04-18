using System.Web.Mvc;
using MonolitoArquiTaller2.Models.DAO;
using MonolitoArquiTaller2.Models.Entities;

namespace MonolitoArquiTaller2.Controllers
{
    public class NotaController : Controller
    {
        private NotaDAO notaDAO = new NotaDAO();
        private EstudianteDAO estudianteDAO = new EstudianteDAO();
        private AsignaturaDAO asignaturaDAO = new AsignaturaDAO();

        // GET: Nota
        public ActionResult Index()
        {
            var lista = notaDAO.ObtenerTodas();
            return View(lista);
        }

        // GET: Nota/Details/5
        public ActionResult Details(int id)
        {
            var nota = notaDAO.ObtenerPorId(id);
            if (nota == null) return HttpNotFound();
            return View(nota);
        }

        // GET: Nota/Create
        public ActionResult Create()
        {
            ViewBag.Estudiantes = new SelectList(estudianteDAO.ObtenerTodos(), "Id", "NombreCompleto");
            ViewBag.Asignaturas = new SelectList(asignaturaDAO.ObtenerTodas(), "Id", "Nombre");
            return View();
        }

        // POST: Nota/Create
        [HttpPost]
        public ActionResult Create(Nota nota)
        {
            if (ModelState.IsValid)
            {
                notaDAO.Crear(nota);
                return RedirectToAction("Index");
            }

            // Si hay error, recargar dropdowns
            ViewBag.Estudiantes = new SelectList(estudianteDAO.ObtenerTodos(), "Id", "NombreCompleto", nota.IdEstudiante);
            ViewBag.Asignaturas = new SelectList(asignaturaDAO.ObtenerTodas(), "Id", "Nombre", nota.IdAsignatura);
            return View(nota);
        }

        // GET: Nota/Delete/5
        public ActionResult Delete(int id)
        {
            var nota = notaDAO.ObtenerPorId(id);
            if (nota == null) return HttpNotFound();
            return View(nota);
        }

        // POST: Nota/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            notaDAO.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
