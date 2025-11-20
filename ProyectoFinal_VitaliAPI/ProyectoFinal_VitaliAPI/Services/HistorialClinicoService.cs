using Microsoft.EntityFrameworkCore;
using ProyectoFinal_VitaliAPI.Data;
using ProyectoFinal_VitaliAPI.Models;

namespace ProyectoFinal_VitaliAPI.Services
{
    public class HistorialClinicoService
    {
        private readonly VitaliDbContext context;

        public HistorialClinicoService(VitaliDbContext context)
        {
            this.context = context;
        }

        // Crear historial
        public async Task<HistorialClinico> CrearAsync(HistorialClinico historial)
        {
            context.HistorialesClinicos.Add(historial);
            await context.SaveChangesAsync();
            return historial;
        }

        // Obtener todos
        public async Task<IEnumerable<HistorialClinico>> GetAllAsync()
        {
            return await context.HistorialesClinicos.ToListAsync();
        }

        // Obtener por ID
        public async Task<HistorialClinico?> GetByIdAsync(Guid id)
        {
            return await context.HistorialesClinicos.FirstOrDefaultAsync(x => x.Id == id);
        }

        // Actualizar
        public async Task<HistorialClinico?> UpdateAsync(Guid id, HistorialClinico model)
        {
            var historial = await context.HistorialesClinicos.FindAsync(id);

            if (historial == null)
                return null;

            historial.PacienteId = model.PacienteId;
            historial.MedicoId = model.MedicoId;
            historial.Diagnostico = model.Diagnostico;
            historial.Tratamiento = model.Tratamiento;
            historial.FechaConsulta = model.FechaConsulta;

            await context.SaveChangesAsync();
            return historial;
        }

        // Eliminar
        public async Task<bool> DeleteAsync(Guid id)
        {
            var historial = await context.HistorialesClinicos.FindAsync(id);

            if (historial == null)
                return false;

            context.HistorialesClinicos.Remove(historial);
            await context.SaveChangesAsync();
            return true;
        }
    }
}