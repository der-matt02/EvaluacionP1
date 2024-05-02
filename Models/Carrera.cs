using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluacionP1.Models
{
    public class Carrera
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }

        public string nombreCarrera { get; set; }

        public string campus { get; set; }
        public int numeroSemestres { get; set; }

        public Carrera(string id, int nombreCarrera, string campus, int numeroSemestres)
        {
            nombreCarrera = nombreCarrera;
            campus = campus;
            numeroSemestres = numeroSemestres;
        }


    }
}
