using System.Web.Mvc;
using MonolitoArquiTaller2.Models.DAO;
using MonolitoArquiTaller2.Models.Entities;

namespace MonolitoArquiTaller2.Controllers
{
    public class AsignaturaController : Controller
    {
        private AsignaturaDAO dao = new AsignaturaDAO();

        // GET: Asignatura
        public ActionResult Index()
        {
            var lista = dao.ObtenerTodas();
            return View(lista);
        }

        // GET: Asignatura/Details/5
        public ActionResult Details(int id)
        {
            var asignatura = dao.ObtenerPorId(id);
            if (asignatura == null) return HttpNotFound();
            return View(asignatura);
        }

        // GET: Asignatura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Asignatura/Create
        [HttpPost]
        public ActionResult Create(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                dao.Crear(asignatura);
                return RedirectToAction("Index");
            }
            return View(asignatura);
        }

        // GET: Asignatura/Edit/5
        public ActionResult Edit(int id)
        {
            var asignatura = dao.ObtenerPorId(id);
            if (asignatura == null) return HttpNotFound();
            return View(asignatura);
        }

        // POST: Asignatura/Edit/5
        [HttpPost]
        public ActionResult Edit(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                dao.Actualizar(asignatura);
                return RedirectToAction("Index");
            }
            return View(asignatura);
        }

        // GET: Asignatura/Delete/5
        public ActionResult Delete(int id)
        {
            var asignatura = dao.ObtenerPorId(id);
            if (asignatura == null) return HttpNotFound();
            return View(asignatura);
        }

        // POST: Asignatura/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            dao.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
