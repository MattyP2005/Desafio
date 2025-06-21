using Flotas.API.Consumer;
using Flotas.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flotas.MVC.Controllers
{
    public class ConductoresController : Controller
    {
        // GET: Conductores
        public ActionResult Index()
        {
            var conductores = Crud<Conductor>.GetAll();
            return View(conductores);
        }

        // GET: Conductores/Details/5
        public ActionResult Details(int id)
        {
            var conductor = Crud<Conductor>.GetById(id);
            return View(conductor);
        }

        // GET: Conductores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conductores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Conductor conductor)
        {
            try
            {
                Crud<Conductor>.Create(conductor);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(conductor);
            }
        }

        // GET: Conductores/Edit/5
        public ActionResult Edit(int id)
        {
            var conductor = Crud<Conductor>.GetById(id);
            return View(conductor);
        }

        // POST: Conductores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Conductor conductor)
        {
            try
            {
                Crud<Conductor>.Update(id, conductor);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(conductor);
            }
        }

        // GET: Conductores/Delete/5
        public ActionResult Delete(int id)
        {
            var conductor = Crud<Conductor>.GetById(id);
            return View(conductor);
        }

        // POST: Conductores/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Conductor conductor)
        {
            try
            {
                Crud<Conductor>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(conductor);
            }
        }
    }
}
