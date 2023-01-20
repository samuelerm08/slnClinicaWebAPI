using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    [Table("Especialidad")]
    public class Habitacion
    {
        public int ID { get; set; }
        [Range(1,100, ErrorMessage = "Solo se permiten numeros entre 1 y 100")]
        public int Numero { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Estado { get; set; }
        public int ClinicaID { get; set; }
        [ForeignKey("ClinicaID")]
        public Clinica Clinica { get; set; }
    }
}
