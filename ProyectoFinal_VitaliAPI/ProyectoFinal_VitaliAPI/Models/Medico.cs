namespace ProyectoFinal_VitaliAPI.Models
{
    public class Medico
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombre { get; set; }
        public string CedulaProfesional { get; set; }
        public string Especialidad { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string HorarioConsulta { get; set; }
        public string Estado { get; set; } // "Activo"/"Inactivo"
    }
}
