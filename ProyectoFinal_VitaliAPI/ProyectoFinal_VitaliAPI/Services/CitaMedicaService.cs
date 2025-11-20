using Microsoft.EntityFrameworkCore;
using ProyectoFinal_VitaliAPI.Data;
using ProyectoFinal_VitaliAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace ProyectoFinal_VitaliAPI.Services
{
    public class CitaMedicaService
    {
        private readonly VitaliDbContext context;

        public CitaMedicaService(VitaliDbContext dbContext)
        {
            context = dbContext;
        }

        // Crear una cita
        public async Task<CitaMedica> CrearCitaAsync(CitaMedica cita)
        {

            if (cita.Fecha < 6)
            {
                context.CitasMedicas.Add(cita);
                await context.SaveChangesAsync();
                return cita;
            }
            else
            {
                return null;
            }
        }


        // Obtener todas las citas
        public async Task<List<CitaMedica>> ObtenerTodasCitasAsync()
        {
            return await context.CitasMedicas.ToListAsync();
        }

        // Obtener cita por ID
        public async Task<CitaMedica?> ObtenerCitaPorIdAsync(Guid id)
        {
            return await context.CitasMedicas.FirstOrDefaultAsync(c => c.Id == id);
        }

        // Actualizar cita
        public async Task<CitaMedica?> ActualizarCitaAsync(Guid id, CitaMedica citaActualizada)
        {
            var citaExistente = await context.CitasMedicas.FindAsync(id);
            if (citaExistente == null)
                return null;

            citaExistente.PacienteId = citaActualizada.PacienteId;
            citaExistente.MedicoId = citaActualizada.MedicoId;
            citaExistente.Fecha = citaActualizada.Fecha;
            citaExistente.espacioDeldia = citaActualizada.espacioDeldia;
            citaExistente.Especialidad = citaActualizada.Especialidad;
            citaExistente.Estado = citaActualizada.Estado;

            await context.SaveChangesAsync();
            return citaExistente;
        }

        // Eliminar cita
        public async Task<bool> EliminarCitaAsync(Guid id)
        {
            var citaExistente = await context.CitasMedicas.FindAsync(id);
            if (citaExistente == null)
                return false;

            context.CitasMedicas.Remove(citaExistente);
            await context.SaveChangesAsync();
            return true;
        }
    }
}