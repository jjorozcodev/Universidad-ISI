using System;
using System.Collections.Generic;

namespace Universidad_ISI.Models
{
    public class Estudiante
    {
        public int EstudianteId { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaInscripcion { get; set; }

        public virtual ICollection<Inscripcion> Inscripciones { get; set; }
    }
}