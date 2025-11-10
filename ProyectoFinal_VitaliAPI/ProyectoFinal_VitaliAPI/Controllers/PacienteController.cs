using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_VitaliAPI.Data;
using ProyectoFinal_VitaliAPI.Models;

namespace ProyectoFinal_VitaliAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly VitaliDbContext _context;
        public PacienteController(VitaliDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _context.Pacientes.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var p = await _context.Pacientes.FindAsync(id);
            if (p == null) return NotFound();
            return Ok(p);
        }

        [HttpGet("buscar/cedula/{cedula}")]
        public async Task<IActionResult> GetByCedula(string cedula)
        {
            var p = await _context.Pacientes.FirstOrDefaultAsync(x => x.Cedula == cedula);
            if (p == null) return NotFound();
            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Paciente paciente)
        {
            if (paciente == null) return BadRequest();
            paciente.Id = Guid.NewGuid();
            paciente.FechaRegistro = DateTime.UtcNow;
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = paciente.Id }, paciente);
        }

        // PUT parcial: sólo actualizar propiedades no nulas
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Paciente update)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return NotFound();

            // validar y asignar solo si no es nulo (o distinto de default)
            if (!string.IsNullOrWhiteSpace(update.Nombre)) paciente.Nombre = update.Nombre;
            if (!string.IsNullOrWhiteSpace(update.Cedula)) paciente.Cedula = update.Cedula;
            if (update.FechaNacimiento != default) paciente.FechaNacimiento = update.FechaNacimiento;
            if (!string.IsNullOrWhiteSpace(update.Genero)) paciente.Genero = update.Genero;
            if (!string.IsNullOrWhiteSpace(update.Direccion)) paciente.Direccion = update.Direccion;
            if (!string.IsNullOrWhiteSpace(update.Telefono)) paciente.Telefono = update.Telefono;
            if (!string.IsNullOrWhiteSpace(update.Correo)) paciente.Correo = update.Correo;
            if (!string.IsNullOrWhiteSpace(update.EstadoClinico)) paciente.EstadoClinico = update.EstadoClinico;
            // No tocamos FechaRegistro

            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
            return Ok(paciente);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return NotFound();
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
