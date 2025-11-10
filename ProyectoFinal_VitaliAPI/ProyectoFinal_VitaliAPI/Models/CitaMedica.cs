namespace ProyectoFinal_VitaliAPI.Models
{
    public class CitaMedica
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }
        public DateTime Fecha { get; set; } // incluye fecha y hora si prefieres
        public string Especialidad { get; set; }
        public string Estado { get; set; } // "Confirmada"/"Cancelada"/"Pendiente"
    }
}
