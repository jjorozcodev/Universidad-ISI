using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Universidad_ISI.Models
{
    public class Estudiante
    {
        public int EstudianteId { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInscripcion { get; set; }

        public virtual ICollection<Inscripcion> Inscripciones { get; set; }
    }
}