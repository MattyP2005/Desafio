using Flotas.API.Consumer;
using Flotas.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flotas.MVC.Controllers
{
    public class AlertasController : Controller
    {
        // GET: Alertas
        public ActionResult Index()
        {
            var alertas = Crud<Alerta>.GetAll();
            return View(alertas);
        }

        // GET: Alertas/Details/5
        public ActionResult Details(int id)
        {
            var alerta = Crud<Alerta>.GetById(id);
            return View(alerta);
        }

        // GET: Alertas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alertas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alerta alerta)
        {
            try
            {
                Crud<Alerta>.Create(alerta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(alerta);
            }
        }

        // GET: Alertas/Edit/5
        public ActionResult Edit(int id)
        {
            var alerta = Crud<Alerta>.GetById(id);
            return View(alerta);
        }

        // POST: Alertas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Alerta alerta)
        {
            try
            {
                Crud<Alerta>.Update(id, alerta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(alerta);
            }
        }

        // GET: Alertas/Delete/5
        public ActionResult Delete(int id)
        {
            var alerta = Crud<Alerta>.GetById(id);
            return View(alerta);
        }

        // POST: Alertas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Alerta alerta)
        {
            try
            {
                Crud<Alerta>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(alerta);
            }
        }
    }
}
