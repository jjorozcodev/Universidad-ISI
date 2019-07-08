using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Universidad_ISI.Models
{
    public class Estudiante
    {
        public int EstudianteId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "El nombre no debe exceder los 50 caracteres.")]
        [Column("Names")]
        [Display(Name = "Nombre")]
        public string Nombres { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Inscripción")]
        public DateTime FechaInscripcion { get; set; }

        [Display(Name = "Nombre Completo")]
        public string FullName
        {
            get
            {
                return Apellidos + ", " + Nombres;
            }
        }

        public virtual ICollection<Inscripcion> Inscripciones { get; set; }
    }
}