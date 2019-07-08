using System.ComponentModel.DataAnnotations;

namespace Universidad_ISI.Models
{
    public enum Nota
    {
        A,B,C,D,F
    }

    public class Inscripcion
    {
        public int InscripcionId { get; set; }
        public int CursoId { get; set; }
        public int EstudianteId { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Nota? Nota { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}