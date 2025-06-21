using Flotas.API.Consumer;
using Flotas.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flotas.MVC.Controllers
{
    public class SensoresLogsController : Controller
    {
        // GET: SensoresLogs
        public ActionResult Index()
        {
            var logs = Crud<SensorLog>.GetAll();
            return View(logs);
        }

        // GET: SensoresLogs/Details/5
        public ActionResult Details(int id)
        {
            var log = Crud<SensorLog>.GetById(id);
            return View(log);
        }

        // GET: SensoresLogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SensoresLogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SensorLog log)
        {
            try
            {
                Crud<SensorLog>.Create(log);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(log);
            }
        }

        // GET: SensoresLogs/Edit/5
        public ActionResult Edit(int id)
        {
            var log = Crud<SensorLog>.GetById(id);
            return View(log);
        }

        // POST: SensoresLogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SensorLog log)
        {
            try
            {
                Crud<SensorLog>.Update(id, log);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(log);
            }
        }

        // GET: SensoresLogs/Delete/5
        public ActionResult Delete(int id)
        {
            var log = Crud<SensorLog>.GetById(id);
            return View(log);
        }

        // POST: SensoresLogs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SensorLog log)
        {
            try
            {
                Crud<SensorLog>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(log);
            }
        }
    }
}
