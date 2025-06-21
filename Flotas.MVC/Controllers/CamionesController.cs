using Flotas.API.Consumer;
using Flotas.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flotas.MVC.Controllers
{
    public class CamionesController : Controller
    {
        // GET: Camiones
        public ActionResult Index()
        {
            var camiones = Crud<Camion>.GetAll();
            return View(camiones);
        }

        // GET: Camiones/Details/5
        public ActionResult Details(int id)
        {
            var camion = Crud<Camion>.GetById(id);
            if (camion == null)
            {
                TempData["Error"] = "El camión no fue encontrado.";
                return RedirectToAction(nameof(Index));
            }
            return View(camion);
        }

        // GET: Camiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Camiones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Camion camion)
        {
            try
            {
                Crud<Camion>.Create(camion);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(camion);
            }
        }

        // GET: Camiones/Edit/5
        public ActionResult Edit(int id)
        {
            var camion = Crud<Camion>.GetById(id);
            if (camion == null)
            {
                TempData["Error"] = "El camión no fue encontrado para edición.";
                return RedirectToAction(nameof(Index));
            }
            return View(camion);
        }

        // POST: Camiones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Camion camion)
        {
            try
            {
                var success = Crud<Camion>.Update(id, camion);
                if (!success)
                {
                    TempData["Error"] = "No se pudo actualizar. El camión no existe.";
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(camion);
            }
        }

        // GET: Camiones/Delete/5
        public ActionResult Delete(int id)
        {
            var camion = Crud<Camion>.GetById(id);
            if (camion == null)
            {
                TempData["Error"] = "No se encontró el camión a eliminar.";
                return RedirectToAction(nameof(Index));
            }
            return View(camion);
        }

        // POST: Camiones/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Camion camion)
        {
            try
            {
                var success = Crud<Camion>.Delete(id);
                if (!success)
                {
                    TempData["Error"] = "No se pudo eliminar. El camión no existe.";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(camion);
            }
        }
    }
}
