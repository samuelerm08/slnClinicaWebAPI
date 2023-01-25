using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSClinica.Models
{
    [Table("Habitacion")]
    public class Habitacion
    {
        public int ID { get; set; }
        
        [RegularExpression(@"^[A]{3}(0[0-9][1-9]|1[0]{2})$", ErrorMessage = "El numero de habitación debe contener tres letras A al inicio y numeros entre 1 y 100\nEJ: AAA000")]
        public string Numero { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Estado { get; set; }
        public int ClinicaID { get; set; }
        [ForeignKey("ClinicaID")]
        public Clinica Clinica { get; set; }
    }
}
