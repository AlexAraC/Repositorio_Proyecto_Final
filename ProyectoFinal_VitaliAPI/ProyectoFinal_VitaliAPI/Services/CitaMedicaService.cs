using ProyectoFinal_VitaliAPI.Models;
using System;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal_VitaliAPI.Data;





namespace ProyectoFinal_VitaliAPI.Services
{
    public class CitaMedicaService
    {
        private readonly VitaliDbContext context;//DbContext para acceder a la base de datos
        public CitaMedicaService(VitaliDbContext dbContext)
        {
            context = dbContext;
        }

    }
}
