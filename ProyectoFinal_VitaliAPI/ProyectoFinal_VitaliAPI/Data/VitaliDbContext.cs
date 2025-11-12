using Microsoft.EntityFrameworkCore;//DbContext, DbSet
using ProyectoFinal_VitaliAPI.Models;

namespace ProyectoFinal_VitaliAPI.Data
{
    public class VitaliDbContext : DbContext
    {
        public VitaliDbContext(DbContextOptions<VitaliDbContext> options) : base(options) { }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<CitaMedica> CitasMedicas { get; set; }
        public DbSet<HistorialClinico> HistorialesClinicos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // índices/unique: por ejemplo Cedula único en Paciente
            modelBuilder.Entity<Paciente>()
                .HasIndex(p => p.Cedula)
                .IsUnique();

            modelBuilder.Entity<Medico>()
                .HasIndex(m => m.CedulaProfesional)
                .IsUnique();
        }
    }
}
