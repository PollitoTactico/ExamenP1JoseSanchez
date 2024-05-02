using System.ComponentModel.DataAnnotations;

namespace ExamenP1JoseSanchez.Models
{
    public class Carrera
    {
        [Key]
        public int IdCarrera { get; set; }
        [Required]
        public string? NombreCarrera { get; set; }
        public string? Campus {  get; set; }
        public int NumSemestre { get; set; }

    }
}
