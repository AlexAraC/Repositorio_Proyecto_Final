using ProyectoFinal_VitaliAPI.Data;

namespace ProyectoFinal_VitaliAPI.Services
{
    public class HistorialClinicoService
    {
        private readonly VitaliDbContext context;//DbContext para acceder a la base de datos
        public HistorialClinicoService(VitaliDbContext dbContext)
        {
            context = dbContext;
        }
    }
}
