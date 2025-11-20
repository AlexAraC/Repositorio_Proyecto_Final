namespace ProyectoFinal_VitaliAPI.Models
{
    public class HistorialClinico
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public DateTime FechaConsulta { get; set; }
    }
}