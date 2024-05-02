using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EvaluacionP1.Models
{
    public class MBaquero
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }
        [Required] public string name { get; set; } = string.Empty;
        public int edad { get; set; }
        [AllowNull]
        public decimal mensualidad { get; set; }
        public DateTime anio { get; set; }
        public bool reprobo { get; set; }

        public MBaquero(string id, string nombre, int edad, decimal mensualidad, DateTime anio, bool reprobo)
        {
            nombre = nombre;
            edad = edad;
            mensualidad = mensualidad;
            anio = anio;
            reprobo = reprobo;
        }

        [ForeignKey("CarreraId")]
        [AllowNull]
        public int CarreraId { get; set; }
        public Carrera? Carrera {get; set; }
    }
}
