namespace ProyectoFinal_VitaliAPI.Models
{
    public class Paciente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; } // "Masculino"/"Femenino"/"Otro"
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string EstadoClinico { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
