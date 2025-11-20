using Microsoft.EntityFrameworkCore;
using ProyectoFinal_VitaliAPI.Data;
using ProyectoFinal_VitaliAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_VitaliAPI.Services
{
    public class HistorialClinicoService
    {
        private readonly VitaliDbContext context;//DbContext para acceder a la base de datos

        public HistorialClinicoService(VitaliDbContext dbContext)
        {
            context = dbContext;
        }

        // CREATE
        public async Task<HistorialClinico> Crear(HistorialClinico historial)
        {
            context.HistorialesClinicos.Add(historial);
            await context.SaveChangesAsync();
            return historial;
        }

        // READ ALL
        public async Task<List<HistorialClinico>> ObtenerTodos()
        {
            return await context.HistorialesClinicos.ToListAsync();
        }

        // READ BY ID
        public async Task<HistorialClinico> ObtenerPorId(int id)
        {
            return await context.HistorialesClinicos.FindAsync(id);
        }

        // UPDATE
        public async Task<HistorialClinico> Actualizar(HistorialClinico historial)
        {
            context.Entry(historial).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return historial;
        }

        // NO DELETE - No se implementa como solicitaste
    }
}