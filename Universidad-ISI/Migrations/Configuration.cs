namespace Universidad_ISI.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Universidad_ISI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Universidad_ISI.Datos.ContextoUniversidad>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Universidad_ISI.Datos.ContextoUniversidad context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var estudiantes = new List<Estudiante>
            {
                new Estudiante { Nombres = "Carson",   Apellidos = "Alexander",
                    FechaInscripcion = DateTime.Parse("2010-09-01") },
                new Estudiante { Nombres = "Meredith", Apellidos = "Alonso",
                    FechaInscripcion = DateTime.Parse("2012-09-01") },
                new Estudiante { Nombres = "Arturo",   Apellidos = "Anand",
                    FechaInscripcion = DateTime.Parse("2013-09-01") },
                new Estudiante { Nombres = "Gytis",    Apellidos = "Barzdukas",
                    FechaInscripcion = DateTime.Parse("2012-09-01") },
                new Estudiante { Nombres = "Yan",      Apellidos = "Li",
                    FechaInscripcion = DateTime.Parse("2012-09-01") },
                new Estudiante { Nombres = "Peggy",    Apellidos = "Justice",
                    FechaInscripcion = DateTime.Parse("2011-09-01") },
                new Estudiante { Nombres = "Laura",    Apellidos = "Norman",
                    FechaInscripcion = DateTime.Parse("2013-09-01") },
                new Estudiante { Nombres = "Nino",     Apellidos = "Olivetto",
                    FechaInscripcion = DateTime.Parse("2005-08-11") }
            };
            estudiantes.ForEach(s => context.Estudiantes.AddOrUpdate(p => p.Apellidos, s));
            context.SaveChanges();

            var cursos = new List<Curso>
            {
                new Curso {CursoId = 1050, Titulo = "Chemistry",      Creditos = 3, },
                new Curso {CursoId = 4022, Titulo = "Microeconomics", Creditos = 3, },
                new Curso {CursoId = 4041, Titulo = "Macroeconomics", Creditos = 3, },
                new Curso {CursoId = 1045, Titulo = "Calculus",       Creditos = 4, },
                new Curso {CursoId = 3141, Titulo = "Trigonometry",   Creditos = 4, },
                new Curso {CursoId = 2021, Titulo = "Composition",    Creditos = 3, },
                new Curso {CursoId = 2042, Titulo = "Literature",     Creditos = 4, }
            };
            cursos.ForEach(s => context.Cursos.AddOrUpdate(p => p.Titulo, s));
            context.SaveChanges();

            var inscripciones = new List<Inscripcion>
            {
                new Inscripcion {
                    EstudianteId = estudiantes.Single(s => s.Apellidos == "Alexander").EstudianteId,
                    CursoId = cursos.Single(c => c.Titulo == "Chemistry" ).CursoId,
                    Nota = Nota.A
                },
                 new Inscripcion {
                    EstudianteId = estudiantes.Single(s => s.Apellidos == "Alexander").EstudianteId,
                    CursoId = cursos.Single(c => c.Titulo == "Microeconomics" ).CursoId,
                    Nota = Nota.C
                 },
                 new Inscripcion {
                    EstudianteId = estudiantes.Single(s => s.Apellidos == "Alexander").EstudianteId,
                    CursoId = cursos.Single(c => c.Titulo == "Macroeconomics" ).CursoId,
                    Nota = Nota.B
                 },
                 new Inscripcion {
                     EstudianteId = estudiantes.Single(s => s.Apellidos == "Alonso").EstudianteId,
                    CursoId = cursos.Single(c => c.Titulo == "Calculus" ).CursoId,
                    Nota = Nota.B
                 },
                 new Inscripcion {
                     EstudianteId = estudiantes.Single(s => s.Apellidos == "Alonso").EstudianteId,
                    CursoId = cursos.Single(c => c.Titulo == "Trigonometry" ).CursoId,
                    Nota = Nota.B
                 },
                 new Inscripcion {
                    EstudianteId = estudiantes.Single(s => s.Apellidos == "Alonso").EstudianteId,
                    CursoId = cursos.Single(c => c.Titulo == "Composition" ).CursoId,
                    Nota = Nota.B
                 },
                 new Inscripcion {
                    EstudianteId = estudiantes.Single(s => s.Apellidos == "Anand").EstudianteId,
                    CursoId = cursos.Single(c => c.Titulo == "Chemistry" ).CursoId,
                    Nota = Nota.B
                 },
                 new Inscripcion {
                    EstudianteId = estudiantes.Single(s => s.Apellidos == "Anand").EstudianteId,
                    CursoId = cursos.Single(c => c.Titulo == "Microeconomics").CursoId,
                    Nota = Nota.B
                 },
                new Inscripcion {
                    EstudianteId = estudiantes.Single(s => s.Apellidos == "Barzdukas").EstudianteId,
                    CursoId = cursos.Single(c => c.Titulo == "Chemistry").CursoId,
                    Nota = Nota.B
                 },
                 new Inscripcion {
                    EstudianteId = estudiantes.Single(s => s.Apellidos == "Li").EstudianteId,
                    CursoId = cursos.Single(c => c.Titulo == "Composition").CursoId,
                    Nota = Nota.B
                 },
                 new Inscripcion {
                    EstudianteId = estudiantes.Single(s => s.Apellidos == "Justice").EstudianteId,
                    CursoId = cursos.Single(c => c.Titulo == "Literature").CursoId,
                    Nota = Nota.B
                 }
            };

            foreach (Inscripcion e in inscripciones)
            {
                var enrollmentInDataBase = context.Inscripciones.Where(
                    s =>
                         s.Estudiante.EstudianteId == e.EstudianteId &&
                         s.Curso.CursoId == e.CursoId).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Inscripciones.Add(e);
                }
            }
            context.SaveChanges();

        }
    }
}
