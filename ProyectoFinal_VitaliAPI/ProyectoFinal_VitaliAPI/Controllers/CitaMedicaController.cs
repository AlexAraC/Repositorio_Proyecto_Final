using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_VitaliAPI.Models;
using ProyectoFinal_VitaliAPI.Services;

namespace ProyectoFinal_VitaliAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaMedicaController : ControllerBase
    {
        private readonly CitaMedicaService citaService;

        public CitaMedicaController(CitaMedicaService service)
        {
            citaService = service;
        }

        // POST -> Crear cita
        [HttpPost]
        public async Task<ActionResult<CitaMedica>> CrearCita(CitaMedica nuevaCita)
        {
            var cita = await citaService.CrearCitaAsync(nuevaCita);
            return Ok(cita);
        }

        // GET -> Listar citas
        [HttpGet]
        public async Task<ActionResult<List<CitaMedica>>> ObtenerTodas()
        {
            return Ok(await citaService.ObtenerTodasCitasAsync());
        }

        // GET -> Buscar cita por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CitaMedica>> ObtenerPorId(Guid id)
        {
            var cita = await citaService.ObtenerCitaPorIdAsync(id);
            if (cita == null)
                return NotFound();
            return Ok(cita);
        }

        // PUT -> Actualizar cita
        [HttpPut("{id}")]
        public async Task<ActionResult<CitaMedica>> Actualizar(Guid id, CitaMedica cita)
        {
            var actualizada = await citaService.ActualizarCitaAsync(id, cita);
            if (actualizada == null)
                return NotFound();
            return Ok(actualizada);
        }

        // DELETE -> Eliminar cita
        [HttpDelete("{id}")]
        public async Task<ActionResult> Eliminar(Guid id)
        {
            var eliminado = await citaService.EliminarCitaAsync(id);
            if (!eliminado)
                return NotFound();
            return Ok(new { mensaje = "Cita eliminada" });
        }
    }
}