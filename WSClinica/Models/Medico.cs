using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    [Table("Medico")]
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Apellido { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }
        public int EspecialidadId { get; set; }
        public int Matricula { get; set; }
        [Column(TypeName = "datetime")]        
        public DateTime? FechaNacimiento { get; set; }
        [ForeignKey("EspecialidadId")]
        public Especialidad Especialidad { get; set; }
        public List<Paciente> Pacientes { get; set; }
    }
}
