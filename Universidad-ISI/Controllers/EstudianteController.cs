using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Universidad_ISI.Datos;
using Universidad_ISI.Models;

namespace Universidad_ISI.Controllers
{
    public class EstudianteController : Controller
    {
        private ContextoUniversidad db = new ContextoUniversidad();

        // GET: Estudiante
        public ActionResult Index(string ordenArreglo)
        {
            ViewBag.OrdenarNombre = String.IsNullOrEmpty(ordenArreglo) ? "nombresDesc" : "";
            ViewBag.OrdenarApellido = ordenArreglo == "apellidosAsc" ? "apellidosDesc" : "apellidosAsc";
            ViewBag.OrdenarFechaInscripcion = ordenArreglo == "fechaAsc" ? "fechaDesc" : "fechaAsc";

            var estudiantes = from s in db.Estudiantes
                           select s;
            switch (ordenArreglo)
            {
                case "nombresDesc":
                    estudiantes = estudiantes.OrderByDescending(s => s.Nombres);
                    break;
                case "apellidosAsc":
                    estudiantes = estudiantes.OrderBy(s => s.Apellidos);
                    break;
                case "apellidosDesc":
                    estudiantes = estudiantes.OrderByDescending(s => s.Apellidos);
                    break;
                case "fechaAsc":
                    estudiantes = estudiantes.OrderBy(s => s.FechaInscripcion);
                    break;
                case "fechaDesc":
                    estudiantes = estudiantes.OrderByDescending(s => s.FechaInscripcion);
                    break;
                default: // Nombres Ascendentes
                    estudiantes = estudiantes.OrderBy(s => s.Nombres);
                    break;
            }

            return View(estudiantes.ToList());
        }

        // GET: Estudiante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // GET: Estudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Apellidos,Nombres,FechaInscripcion")] Estudiante estudiante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Estudiantes.Add(estudiante);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "No se pueden guardar los cambios. Intente de nuevo, y si el problema persiste contacte al administrador del sistema.");
            }
            
            return View(estudiante);
        }

        // GET: Estudiante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var estudianteActualizar = db.Estudiantes.Find(id);
            if (TryUpdateModel(estudianteActualizar, "",
               new string[] { "Apellidos", "Nombres", "FechaInscripcion" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "No se pueden guardar los cambios. Intente de nuevo, y si el problema persiste contacte al administrador del sistema.");
                }
            }
            return View(estudianteActualizar);
        }
        
        // GET: Estudiante/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Eliminación fallida. Intente de nuevo, y si el problema persiste contacte al administrador del sistema.";
            }
            Estudiante estudiante = db.Estudiantes.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiante/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Estudiante estudiante = db.Estudiantes.Find(id);
                db.Estudiantes.Remove(estudiante);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
