using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    [Table("Clinica")]
    public class Clinica
    {
        public int ID { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }
        public DateTime? FechaInicioActividades { get; set; }
        [Column(TypeName = "varchar(60)")]
        [Required]
        public string Email { get; set; }
        public List<Habitacion> Habitaciones { get; set; }
    }
}
