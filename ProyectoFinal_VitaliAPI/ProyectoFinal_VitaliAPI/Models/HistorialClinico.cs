using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_VitaliAPI.Models
{
    public class HistorialClinico
    {
        public int Id { get; set; }

        [Required]
        public int PacienteId { get; set; }

        [Required]
        public string Diagnostico { get; set; }

        public string Tratamiento { get; set; }

        public string Medicamentos { get; set; }

        public string Alergias { get; set; }

        public string AntecedentesFamiliares { get; set; }

        public string Notas { get; set; }

        public DateTime FechaConsulta { get; set; } = DateTime.Now;
    }
}