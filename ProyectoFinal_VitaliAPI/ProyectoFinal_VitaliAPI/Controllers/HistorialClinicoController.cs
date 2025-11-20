using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_VitaliAPI.Models;
using ProyectoFinal_VitaliAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoFinal_VitaliAPI.Controllers
{
    public class HistorialClinicoController : Controller
    {
        private readonly HistorialClinicoService _historialService;

        public HistorialClinicoController(HistorialClinicoService historialService)
        {
            _historialService = historialService;
        }

        // GET: HistorialClinicoController
        public async Task<ActionResult> Index()
        {
            var historiales = await _historialService.ObtenerTodos();
            return View(historiales);
        }

        // GET: HistorialClinicoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var historial = await _historialService.ObtenerPorId(id);
            if (historial == null)
            {
                return NotFound();
            }
            return View(historial);
        }

        // GET: HistorialClinicoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistorialClinicoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(HistorialClinico historial)
        {
            if (ModelState.IsValid)
            {
                await _historialService.Crear(historial);
                return RedirectToAction(nameof(Index));
            }
            return View(historial);
        }

        // GET: HistorialClinicoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var historial = await _historialService.ObtenerPorId(id);
            if (historial == null)
            {
                return NotFound();
            }
            return View(historial);
        }

        // POST: HistorialClinicoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, HistorialClinico historial)
        {
            if (id != historial.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _historialService.Actualizar(historial);
                return RedirectToAction(nameof(Index));
            }
            return View(historial);
        }

        // GET: HistorialClinicoController/Delete/5
        public ActionResult Delete(int id)
        {
            // No se implementa delete
            return RedirectToAction(nameof(Index));
        }

        // POST: HistorialClinicoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            // No se implementa delete
            return RedirectToAction(nameof(Index));
        }
    }
}