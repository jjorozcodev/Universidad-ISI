using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universidad_ISI.Models
{
    public class Curso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CursoId { get; set; }
        public string Titulo { get; set; }
        public int Creditos { get; set; }

        public virtual ICollection<Inscripcion> Inscripciones { get; set; }
    }
}