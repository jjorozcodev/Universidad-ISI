using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universidad_ISI.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        
        [Display(Name = "Apellido"), StringLength(50, MinimumLength = 1)]
        public string Apellidos { get; set; }

        [Column("Nombre"), Display(Name = "Nombre"), StringLength(50, MinimumLength = 1)]
        public string Nombres { get; set; }

        [DataType(DataType.Date), Display(Name = "Contratado"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaContratacion { get; set; }

        [Display(Name = "Nombre Completo")]
        public string NombreCompleto
        {
            get { return Apellidos + ", " + Nombres; }
        }

        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual OficinaAsignada OficinasAsignada { get; set; }
    }
}