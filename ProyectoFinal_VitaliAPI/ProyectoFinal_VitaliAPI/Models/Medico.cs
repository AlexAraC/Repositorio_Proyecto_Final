using System;//Importaciones basicas GUid, DateTime
using System.Collections.Generic;//Importaciones para List
using System.ComponentModel.DataAnnotations;//Atribhutos como [Key], [Required]
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;//Atributos de esquema como [ForeignKey] o [NotMapped]
namespace ProyectoFinal_VitaliAPI.Models
{
    public class Medico
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();//inicia automaticamente con un nuevo Guid

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string CedulaProfesional { get; set; }

        [Required]
        public string Especialidad { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Correo { get; set; }

        [Required]
        public string Estado { get; set; } // "Activo" / "Inactivo"

        //  Relación uno a muchos con HorarioConsulta
        public List<HorarioConsulta> HorariosConsulta { get; set; } = new List<HorarioConsulta>();//relacion uno a muchos
    }

    public class HorarioConsulta
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid(); // Clave primaria

        [Required]
        public int DiaSemana { get; set; } //0 = Domingo, 1=Lunes, ..., 6=Sábado

        public string Espacio1 { get; set; } = "Vacio"; // "Vacio" o "Ocupado"
        public string Espacio2 { get; set; } = "Vacio";
        public string Espacio3 { get; set; } = "Vacio";
        public string Espacio4 { get; set; } = "Vacio";

        //Relacion  (clave foranea)
        [ForeignKey("Medico")]
        public Guid MedicoId { get; set; }
        [JsonIgnore]
        public Medico? Medico { get; set; }
    }
}
