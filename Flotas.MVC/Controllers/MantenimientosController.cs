using Flotas.API.Consumer;
using Flotas.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flotas.MVC.Controllers
{
    public class MantenimientosController : Controller
    {
        // GET: Mantenimientos
        public ActionResult Index()
        {
            var mantenimientos = Crud<Mantenimiento>.GetAll();
            return View(mantenimientos);
        }

        // GET: Mantenimientos/Details/5
        public ActionResult Details(int id)
        {
            var mantenimiento = Crud<Mantenimiento>.GetById(id);
            return View(mantenimiento);
        }

        // GET: Mantenimientos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mantenimientos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mantenimiento mantenimiento)
        {
            try
            {
                Crud<Mantenimiento>.Create(mantenimiento);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(mantenimiento);
            }
        }

        // GET: Mantenimientos/Edit/5
        public ActionResult Edit(int id)
        {
            var mantenimiento = Crud<Mantenimiento>.GetById(id);
            return View(mantenimiento);
        }

        // POST: Mantenimientos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Mantenimiento mantenimiento)
        {
            try
            {
                Crud<Mantenimiento>.Update(id, mantenimiento);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(mantenimiento);
            }
        }

        // GET: Mantenimientos/Delete/5
        public ActionResult Delete(int id)
        {
            var mantenimiento = Crud<Mantenimiento>.GetById(id);
            return View(mantenimiento);
        }

        // POST: Mantenimientos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Mantenimiento mantenimiento)
        {
            try
            {
                Crud<Mantenimiento>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(mantenimiento);
            }
        }
    }
}
