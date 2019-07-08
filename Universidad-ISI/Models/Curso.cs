using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universidad_ISI.Models
{
    public class Curso
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CursoId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Titulo { get; set; }

        [Range(0, 5)]
        public int Creditos { get; set; }

        public int DepartamentoId { get; set; }

        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<Inscripcion> Inscripciones { get; set; }
        public virtual ICollection<Instructor> Instructores { get; set; }





    }
}