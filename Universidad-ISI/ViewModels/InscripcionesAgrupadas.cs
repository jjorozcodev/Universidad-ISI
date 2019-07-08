using System;
using System.ComponentModel.DataAnnotations;

namespace Universidad_ISI.ViewModels
{
    public class InscripcionesAgrupadas
    {
        [DataType(DataType.Date)]
        public DateTime? FechaInscripcion { get; set; }

        public int CantidadEstudiantes { get; set; }
    }
}