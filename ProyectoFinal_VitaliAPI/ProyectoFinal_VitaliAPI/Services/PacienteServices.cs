using ProyectoFinal_VitaliAPI.Models;
using System;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_VitaliAPI.Data;

namespace ProyectoFinal_VitaliAPI.Services
{
    public class PacienteServices
    {
        private readonly VitaliDbContext context;

        public PacienteServices(VitaliDbContext dbContext)
        {
            context = dbContext;
        }
        //Crear un nuevo paciente
        public async Task<Paciente> CrearPacienteAsync(Paciente paciente)
        {
            context.Pacientes.Add(paciente);
            await context.SaveChangesAsync();
            return paciente;
        }
        //Obtener todos los pacientes
        public async Task<List<Paciente>> ObtenerTodosPacientesAsync()
        {
            return await context.Pacientes
                .ToListAsync();
        }
        //Obtener paciente por cedula
        public async Task<Paciente?> ObtenerPacientePorCedulaAsync(string cedula)
        {
            return await context.Pacientes
                .FirstOrDefaultAsync(p => p.Cedula == cedula);
        }

        //Actualizar paciente
        public async Task<Paciente?> ActualizarPacienteAsync(Guid id, Paciente pacienteActualizado)
        {
            var pacienteExistente = await context.Pacientes.FindAsync(id);
            if (pacienteExistente == null)
            {
                return null;
            }
            pacienteExistente.Nombre = pacienteActualizado.Nombre;
            pacienteExistente.Cedula = pacienteActualizado.Cedula;
            pacienteExistente.FechaNacimiento = pacienteActualizado.FechaNacimiento;
            pacienteExistente.Telefono = pacienteActualizado.Telefono;
            pacienteExistente.Correo = pacienteActualizado.Correo;
            pacienteExistente.Direccion = pacienteActualizado.Direccion;
            await context.SaveChangesAsync();
            return pacienteExistente;
        }
        //Eliminar paciente
        public async Task<bool> EliminarPacienteAsync(Guid id)
        {
            var pacienteExistente = await context.Pacientes.FindAsync(id);
            if (pacienteExistente == null)
            {
                return false;
            }
            context.Pacientes.Remove(pacienteExistente);
            await context.SaveChangesAsync();
            return true;
        }

    }
}
