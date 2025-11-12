using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_VitaliAPI.Models;
using ProyectoFinal_VitaliAPI.Services;
namespace ProyectoFinal_VitaliAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly MedicoService _medicoService;

        public MedicoController(MedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        // 🔹 Crear un nuevo médico
        [HttpPost]
        public async Task<IActionResult> CrearMedico([FromBody] Medico medico)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nuevoMedico = await _medicoService.CrearMedicoAsync(medico);//vamos los servicios
            return CreatedAtAction(nameof(ObtenerMedicoPorId), new { id = nuevoMedico.Id }, nuevoMedico);
        }

        // 🔹 Obtener todos los médicos
        [HttpGet]
        public async Task<IActionResult> ObtenerTodosMedicos()
        {
            var medicos = await _medicoService.ObtenerTodosMedicosAsync();
            return Ok(medicos);
        }

        // 🔹 Obtener médico por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerMedicoPorId(Guid id)
        {
            var medico = await _medicoService.ObtenerMedicoPorIdAsync(id);
            if (medico == null)
                return NotFound(new { mensaje = "Médico no encontrado" });

            return Ok(medico);
        }

        // 🔹 Actualizar un médico existente
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarMedico(Guid id, [FromBody] Medico medicoActualizado)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var medico = await _medicoService.ActualizarMedicoAsync(id, medicoActualizado);
            if (medico == null)
                return NotFound(new { mensaje = "Médico no encontrado para actualizar" });

            return Ok(medico);
        }

        // 🔹 Eliminar un médico
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarMedico(Guid id)
        {
            var eliminado = await _medicoService.EliminarMedicoAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Médico no encontrado para eliminar" });

            return Ok(new { mensaje = "Médico eliminado correctamente" });
        }
    }
}
