namespace Universidad_ISI.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Universidad_ISI.Models;
    using Universidad_ISI.Datos;

    internal sealed class Configuration : DbMigrationsConfiguration<Universidad_ISI.Datos.ContextoUniversidad>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContextoUniversidad context)
        {
            var Estudiantes = new List<Estudiante>
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
                    FechaInscripcion = DateTime.Parse("2005-09-01") }
            };

            Estudiantes.ForEach(s => context.Estudiantes.AddOrUpdate(p => p.Apellidos, s));
            context.SaveChanges();

            var instructores = new List<Instructor>
            {
                new Instructor { Nombres = "Kim",     Apellidos = "Abercrombie",
                    FechaContratacion = DateTime.Parse("1995-03-11") },
                new Instructor { Nombres = "Fadi",    Apellidos = "Fakhouri",
                    FechaContratacion = DateTime.Parse("2002-07-06") },
                new Instructor { Nombres = "Roger",   Apellidos = "Harui",
                    FechaContratacion = DateTime.Parse("1998-07-01") },
                new Instructor { Nombres = "Candace", Apellidos = "Kapoor",
                    FechaContratacion = DateTime.Parse("2001-01-15") },
                new Instructor { Nombres = "Roger",   Apellidos = "Zheng",
                    FechaContratacion = DateTime.Parse("2004-02-12") }
            };
            instructores.ForEach(s => context.Instructores.AddOrUpdate(p => p.Apellidos, s));
            context.SaveChanges();

            var departamentos = new List<Departamento>
            {
                new Departamento { Nombre = "English",     Presupuesto = 350000,
                    FechaInicio = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructores.Single( i => i.Apellidos == "Abercrombie").ID },
                new Departamento { Nombre = "Mathematics", Presupuesto = 100000,
                    FechaInicio = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructores.Single( i => i.Apellidos == "Fakhouri").ID },
                new Departamento { Nombre = "Engineering", Presupuesto = 350000,
                    FechaInicio = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructores.Single( i => i.Apellidos == "Harui").ID },
                new Departamento { Nombre = "Economics",   Presupuesto = 100000,
                    FechaInicio = DateTime.Parse("2007-09-01"),
                    InstructorID  = instructores.Single( i => i.Apellidos == "Kapoor").ID }
            };
            departamentos.ForEach(s => context.Departmentos.AddOrUpdate(p => p.Nombre, s));
            context.SaveChanges();

            var Cursos = new List<Curso>
            {
                new Curso {CursoId = 1050, Titulo = "Chemistry",      Creditos = 3,
                  DepartamentoId = departamentos.Single( s => s.Nombre == "Engineering").DepartamentoId,
                  Instructores = new List<Instructor>()
                },
                new Curso {CursoId = 4022, Titulo = "Microeconomics", Creditos = 3,
                  DepartamentoId = departamentos.Single( s => s.Nombre == "Economics").DepartamentoId,
                  Instructores = new List<Instructor>()
                },
                new Curso {CursoId = 4041, Titulo = "Macroeconomics", Creditos = 3,
                  DepartamentoId = departamentos.Single( s => s.Nombre == "Economics").DepartamentoId,
                  Instructores = new List<Instructor>()
                },
                new Curso {CursoId = 1045, Titulo = "Calculus",       Creditos = 4,
                  DepartamentoId = departamentos.Single( s => s.Nombre == "Mathematics").DepartamentoId,
                  Instructores = new List<Instructor>()
                },
                new Curso {CursoId = 3141, Titulo = "Trigonometry",   Creditos = 4,
                  DepartamentoId = departamentos.Single( s => s.Nombre == "Mathematics").DepartamentoId,
                  Instructores = new List<Instructor>()
                },
                new Curso {CursoId = 2021, Titulo = "Composition",    Creditos = 3,
                  DepartamentoId = departamentos.Single( s => s.Nombre == "English").DepartamentoId,
                  Instructores = new List<Instructor>()
                },
                new Curso {CursoId = 2042, Titulo = "Literature",     Creditos = 4,
                  DepartamentoId = departamentos.Single( s => s.Nombre == "English").DepartamentoId,
                  Instructores = new List<Instructor>()
                },
            };
            Cursos.ForEach(s => context.Cursos.AddOrUpdate(p => p.CursoId, s));
            context.SaveChanges();

            var OficinaAsignadas = new List<OficinaAsignada>
            {
                new OficinaAsignada {
                    InstructorID = instructores.Single( i => i.Apellidos == "Fakhouri").ID,
                    Location = "Smith 17" },
                new OficinaAsignada {
                    InstructorID = instructores.Single( i => i.Apellidos == "Harui").ID,
                    Location = "Gowan 27" },
                new OficinaAsignada {
                    InstructorID = instructores.Single( i => i.Apellidos == "Kapoor").ID,
                    Location = "Thompson 304" },
            };
            OficinaAsignadas.ForEach(s => context.OficinasAsignadas.AddOrUpdate(p => p.InstructorID, s));
            context.SaveChanges();

            AddOrUpdateInstructor(context, "Chemistry", "Kapoor");
            AddOrUpdateInstructor(context, "Chemistry", "Harui");
            AddOrUpdateInstructor(context, "Microeconomics", "Zheng");
            AddOrUpdateInstructor(context, "Macroeconomics", "Zheng");

            AddOrUpdateInstructor(context, "Calculus", "Fakhouri");
            AddOrUpdateInstructor(context, "Trigonometry", "Harui");
            AddOrUpdateInstructor(context, "Composition", "Abercrombie");
            AddOrUpdateInstructor(context, "Literature", "Abercrombie");

            context.SaveChanges();

            var Inscripcions = new List<Inscripcion>
            {
                new Inscripcion {
                    EstudianteId = Estudiantes.Single(s => s.Apellidos == "Alexander").EstudianteId,
                    CursoId = Cursos.Single(c => c.Titulo == "Chemistry" ).CursoId,
                    Nota = Nota.A
                },
                 new Inscripcion {
                    EstudianteId = Estudiantes.Single(s => s.Apellidos == "Alexander").EstudianteId,
                    CursoId = Cursos.Single(c => c.Titulo == "Microeconomics" ).CursoId,
                    Nota = Nota.C
                 },
                 new Inscripcion {
                    EstudianteId = Estudiantes.Single(s => s.Apellidos == "Alexander").EstudianteId,
                    CursoId = Cursos.Single(c => c.Titulo == "Macroeconomics" ).CursoId,
                    Nota = Nota.B
                 },
                 new Inscripcion {
                     EstudianteId = Estudiantes.Single(s => s.Apellidos == "Alonso").EstudianteId,
                    CursoId = Cursos.Single(c => c.Titulo == "Calculus" ).CursoId,
                    Nota = Nota.B
                 },
                 new Inscripcion {
                     EstudianteId = Estudiantes.Single(s => s.Apellidos == "Alonso").EstudianteId,
                    CursoId = Cursos.Single(c => c.Titulo == "Trigonometry" ).CursoId,
                    Nota = Nota.B
                 },
                 new Inscripcion {
                    EstudianteId = Estudiantes.Single(s => s.Apellidos == "Alonso").EstudianteId,
                    CursoId = Cursos.Single(c => c.Titulo == "Composition" ).CursoId,
                    Nota = Nota.B
                 },
                 new Inscripcion {
                    EstudianteId = Estudiantes.Single(s => s.Apellidos == "Anand").EstudianteId,
                    CursoId = Cursos.Single(c => c.Titulo == "Chemistry" ).CursoId
                 },
                 new Inscripcion {
                    EstudianteId = Estudiantes.Single(s => s.Apellidos == "Anand").EstudianteId,
                    CursoId = Cursos.Single(c => c.Titulo == "Microeconomics").CursoId,
                    Nota = Nota.B
                 },
                new Inscripcion {
                    EstudianteId = Estudiantes.Single(s => s.Apellidos == "Barzdukas").EstudianteId,
                    CursoId = Cursos.Single(c => c.Titulo == "Chemistry").CursoId,
                    Nota = Nota.B
                 },
                 new Inscripcion {
                    EstudianteId = Estudiantes.Single(s => s.Apellidos == "Li").EstudianteId,
                    CursoId = Cursos.Single(c => c.Titulo == "Composition").CursoId,
                    Nota = Nota.B
                 },
                 new Inscripcion {
                    EstudianteId = Estudiantes.Single(s => s.Apellidos == "Justice").EstudianteId,
                    CursoId = Cursos.Single(c => c.Titulo == "Literature").CursoId,
                    Nota = Nota.B
                 }
            };

            foreach (Inscripcion e in Inscripcions)
            {
                var InscripcionInDataBase = context.Inscripciones.Where(
                    s =>
                         s.Estudiante.EstudianteId == e.EstudianteId &&
                         s.Curso.CursoId == e.CursoId).SingleOrDefault();
                if (InscripcionInDataBase == null)
                {
                    context.Inscripciones.Add(e);
                }
            }
            context.SaveChanges();
        }

        void AddOrUpdateInstructor(ContextoUniversidad context, string CursoTitulo, string instructorName)
        {
            var crs = context.Cursos.SingleOrDefault(c => c.Titulo == CursoTitulo);
            var inst = crs.Instructores.SingleOrDefault(i => i.Apellidos == instructorName);
            if (inst == null)
                crs.Instructores.Add(context.Instructores.Single(i => i.Apellidos == instructorName));
        }
    }
}
