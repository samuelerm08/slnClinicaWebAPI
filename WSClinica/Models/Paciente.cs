﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    [Table("Paciente")]
    public class Paciente
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Apellido { get; set; }
        public int NroHistClinica { get; set; }
        public int MedicoId { get; set; }
        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }
    }
}
