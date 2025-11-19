using Microsoft.EntityFrameworkCore;//DbContext, Include, ToListAsync, FirstOrDefaultAsync
using ProyectoFinal_VitaliAPI.Data;
using ProyectoFinal_VitaliAPI.Models;

namespace ProyectoFinal_VitaliAPI.Services
{
    public class MedicoService
    {
        private readonly VitaliDbContext context;//DbContext para acceder a la base de datos
        public MedicoService(VitaliDbContext dbContext)
        {
            context = dbContext;
        }
        //Crear un nuevo medico
        public async Task<Medico> CrearMedicoAsync(Medico medico)
        {
            // Asegura que cada horario tenga asignado el ID del médico
            foreach (var horario in medico.HorariosConsulta)
            {
                horario.MedicoId = medico.Id;
            }

            context.Medicos.Add(medico);
            await context.SaveChangesAsync();

            return medico;
        }

        //Obtener todos los medicos
        public async Task<List<Medico>> ObtenerTodosMedicosAsync()
        {
            return await context.Medicos
                .ToListAsync();
        }
        //Obtener medico por id
        public async Task<Medico?> ObtenerMedicoPorIdAsync(Guid id)
        {
            return await context.Medicos
                .Include(m => m.HorariosConsulta) // Incluir horarios de consulta
                .FirstOrDefaultAsync(m => m.Id == id);
        }
        //Actualizar medico
        public async Task<Medico?> ActualizarMedicoAsync(Guid id, Medico medicoActualizado)
        {
            var medicoExistente = await context.Medicos.FindAsync(id);
            if (medicoExistente == null)
            {
                return null;
            }
            medicoExistente.Nombre = medicoActualizado.Nombre;
            medicoExistente.CedulaProfesional = medicoActualizado.CedulaProfesional;
            medicoExistente.Especialidad = medicoActualizado.Especialidad;
            medicoExistente.Telefono = medicoActualizado.Telefono;
            medicoExistente.Correo = medicoActualizado.Correo;
            medicoExistente.Estado = medicoActualizado.Estado;
            await context.SaveChangesAsync();
            return medicoExistente;
        }
        //Eliminar medico
        public async Task<bool> EliminarMedicoAsync(Guid id)
        {
            var medicoExistente = await context.Medicos.FindAsync(id);
            if (medicoExistente == null)
            {
                return false;
            }
            context.Medicos.Remove(medicoExistente);
            await context.SaveChangesAsync();
            return true;
        }
        

    }
}
