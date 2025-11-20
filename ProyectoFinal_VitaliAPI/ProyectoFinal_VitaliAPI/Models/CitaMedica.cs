namespace ProyectoFinal_VitaliAPI.Models
{
    public class CitaMedica
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }
        public int Fecha { get; set; } // incluye fecha y hora si prefieres
        public string espacioDeldia { get; set; } // "Espacio1"/"Espacio2"/"Espacio3"/"Espacio4"
        public string Especialidad { get; set; }
        public string Estado { get; set; } // "Confirmada"/"Cancelada"/"Pendiente"
        public object Paciente { get; internal set; }
    }
}
