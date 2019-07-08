using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Universidad_ISI.Datos;
using Universidad_ISI.ViewModels;

namespace Universidad_ISI.Controllers
{
    public class HomeController : Controller
    {
        private ContextoUniversidad bd = new ContextoUniversidad();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            IQueryable<InscripcionesAgrupadas> data = from estudiante in bd.Estudiantes
                                                   group estudiante by estudiante.FechaInscripcion into dateGroup
                                                   select new InscripcionesAgrupadas()
                                                   {
                                                       FechaInscripcion = dateGroup.Key,
                                                       CantidadEstudiantes = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            bd.Dispose();
            base.Dispose(disposing);
        }
    }
}