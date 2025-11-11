using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal_VitaliAPI.Controllers
{
    public class CitaMedicaController : Controller
    {
        // GET: CitaMedicaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CitaMedicaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CitaMedicaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CitaMedicaController/Create
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

        // GET: CitaMedicaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CitaMedicaController/Edit/5
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

        // GET: CitaMedicaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CitaMedicaController/Delete/5
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
