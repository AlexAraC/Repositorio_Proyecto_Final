using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_VitaliAPI.Models;
using ProyectoFinal_VitaliAPI.Services;

namespace ProyectoFinal_VitaliAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialClinicoController : ControllerBase
    {
        private readonly HistorialClinicoService service;

        public HistorialClinicoController(HistorialClinicoService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Crear(HistorialClinico historial)
        {
            var result = await service.CrearAsync(historial);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var data = await service.GetByIdAsync(id);
            if (data == null) return NotFound("No existe historial con ese ID");
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, HistorialClinico historial)
        {
            var data = await service.UpdateAsync(id, historial);
            if (data == null) return NotFound("No existe historial con ese ID");
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await service.DeleteAsync(id);
            if (!deleted) return NotFound("No existe historial con ese ID");
            return Ok("Historial eliminado");
        }
    }
}