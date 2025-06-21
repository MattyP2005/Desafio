using Flotas.API.Consumer;
using Flotas.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flotas.MVC.Controllers
{
    public class TalleresController : Controller
    {
        // GET: TalleresController
        public ActionResult Index()
        {
            var talleres = Crud<Taller>.GetAll();
            return View(talleres);
        }

        // GET: TalleresController/Details/5
        public ActionResult Details(int id)
        {
            var taller = Crud<Taller>.GetById(id);
            return View(taller);
        }

        // GET: TalleresController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TalleresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Taller taller)
        {
            try
            {
                Crud<Taller>.Create(taller);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(taller);
            }
        }

        // GET: TalleresController/Edit/5
        public ActionResult Edit(int id)
        {
            var taller = Crud<Taller>.GetById(id);
            return View(taller);
        }

        // POST: TalleresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Taller taller)
        {
            try
            {
                Crud<Taller>.Update(id, taller);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(taller);
            }
        }

        // GET: TalleresController/Delete/5
        public ActionResult Delete(int id)
        {
            var taller = Crud<Taller>.GetById(id);
            return View(taller);
        }

        // POST: TalleresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Taller taller)
        {
            try
            {
                Crud<Taller>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(taller);
            }
        }
    }
}