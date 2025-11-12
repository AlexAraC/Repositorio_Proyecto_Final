using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_VitaliAPI.Models;

namespace ProyectoFinal_VitaliAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : Controller
    {
        private readonly Services.PacienteServices _pacienteServices;

        public PacienteController(Services.PacienteServices pacienteServices)
        {
            _pacienteServices = pacienteServices;
        }

        // ✅ GET: api/Paciente (obtener todos)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pacientes = await _pacienteServices.ObtenerTodosPacientesAsync();
            return Ok(pacientes);
        }

        // ✅ GET: api/Paciente/{cedula} (obtener por cédula)
        [HttpGet("{cedula}")]
        public async Task<IActionResult> GetByCedula(string cedula)
        {
            var paciente = await _pacienteServices.ObtenerPacientePorCedulaAsync(cedula);
            if (paciente == null)
                return NotFound(new { mensaje = "Paciente no encontrado" });

            return Ok(paciente);
        }

        // ✅ POST: api/Paciente (crear paciente)
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Paciente nuevoPaciente)
        {
            if (nuevoPaciente == null)
                return BadRequest(new { mensaje = "Los datos del paciente son requeridos." });

            var pacienteCreado = await _pacienteServices.CrearPacienteAsync(nuevoPaciente);
            return CreatedAtAction(nameof(GetByCedula), new { cedula = pacienteCreado.Cedula }, pacienteCreado);
        }

        // ✅ PUT: api/Paciente/{id} (actualizar)
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(Guid id, [FromBody] Paciente pacienteActualizado)
        {
            var pacienteExistente = await _pacienteServices.ActualizarPacienteAsync(id, pacienteActualizado);
            if (pacienteExistente == null)
                return NotFound(new { mensaje = "Paciente no encontrado" });

            return Ok(new { mensaje = "Paciente actualizado exitosamente" });
        }

        // ✅ DELETE: api/Paciente/{id} (eliminar)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Borrar(Guid id)
        {
            var eliminado = await _pacienteServices.EliminarPacienteAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Paciente no encontrado" });

            return Ok(new { mensaje = "Paciente eliminado exitosamente" });
        }
    }
}
