using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenP1JoseSanchez.Models
{
    public class JSanchez
    {
        [Key]
        public int IdSanchez {  get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Display(Name = "Es de la Ulda")]
        public bool EsdelaUdla { get; set; }
       
        public DateTime FechaNacimeinto { get; set; }
        [ForeignKey("CarreraIdCarrera")]
        public int CarreraIdCarrera { get; set; }
        public Carrera? Carrera { get; set; }

    }
}
