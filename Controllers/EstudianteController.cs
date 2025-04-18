using System.Web.Mvc;
using MonolitoArquiTaller2.Models.Entities;
using MonolitoArquiTaller2.Models.DAO;

namespace MonolitoArquiTaller2.Controllers
{
    public class EstudianteController : Controller
    {
        private EstudianteDAO dao = new EstudianteDAO();

        // GET: Estudiante
        public ActionResult Index()
        {
            var lista = dao.ObtenerTodos();
            return View(lista);
        }

        // GET: Estudiante/Details/5
        public ActionResult Details(int id)
        {
            var estudiante = dao.ObtenerPorId(id);
            if (estudiante == null)
                return HttpNotFound();

            return View(estudiante);
        }

        // GET: Estudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        [HttpPost]
        public ActionResult Create(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                dao.Crear(estudiante);
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        // GET: Estudiante/Edit/5
        public ActionResult Edit(int id)
        {
            var estudiante = dao.ObtenerPorId(id);
            if (estudiante == null)
                return HttpNotFound();

            return View(estudiante);
        }

        // POST: Estudiante/Edit/5
        [HttpPost]
        public ActionResult Edit(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                dao.Actualizar(estudiante);
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        // GET: Estudiante/Delete/5
        public ActionResult Delete(int id)
        {
            var estudiante = dao.ObtenerPorId(id);
            if (estudiante == null)
                return HttpNotFound();

            return View(estudiante);
        }

        // POST: Estudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            dao.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
