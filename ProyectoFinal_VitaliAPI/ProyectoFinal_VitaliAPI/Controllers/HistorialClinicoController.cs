using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal_VitaliAPI.Controllers
{
    public class HistorialClinicoController : Controller
    {
        // GET: HistorialClinicoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HistorialClinicoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HistorialClinicoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistorialClinicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HistorialClinicoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistorialClinicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HistorialClinicoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistorialClinicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
