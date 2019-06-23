using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Universidad_ISI.Models;
using System.Data.Entity;

namespace Universidad_ISI.Datos
{
    public class InicializadorBD : DropCreateDatabaseIfModelChanges<ContextoUniversidad>
    {
        protected override void Seed(ContextoUniversidad context)
        {
            //base.Seed(context);

            var Estudiantes = new List<Estudiante>
            {
                new Estudiante{Nombres="Carson", Apellidos="Alexander", FechaInscripcion=DateTime.Parse("2005-09-01")},
                new Estudiante{Nombres="Meredith", Apellidos="Alonso", FechaInscripcion=DateTime.Parse("2002-09-01")},
                new Estudiante{Nombres="Arturo", Apellidos="Anand", FechaInscripcion=DateTime.Parse("2003-09-01")},
                new Estudiante{Nombres="Gytis", Apellidos="Barzdukas", FechaInscripcion=DateTime.Parse("2002-09-01")},
                new Estudiante{Nombres="Yan", Apellidos="Li", FechaInscripcion=DateTime.Parse("2002-09-01")},
                new Estudiante{Nombres="Peggy", Apellidos="Justice", FechaInscripcion=DateTime.Parse("2001-09-01")},
                new Estudiante{Nombres="Laura", Apellidos="Norman", FechaInscripcion=DateTime.Parse("2003-09-01")},
                new Estudiante{Nombres="Nino", Apellidos="Olivetto", FechaInscripcion=DateTime.Parse("2005-09-01")}
            };

            Estudiantes.ForEach(e => context.Estudiantes.Add(e));

            context.SaveChanges();

            var Cursos = new List<Curso>
            {
                new Curso{ CursoId=1050, Titulo="Chemistry", Creditos=3,},
                new Curso{ CursoId=4022, Titulo="Microeconomics", Creditos=3,},
                new Curso{ CursoId=4041, Titulo="Macroeconomics", Creditos=3,},
                new Curso{ CursoId=1045, Titulo="Calculus", Creditos=4,},
                new Curso{ CursoId=3141, Titulo="Trigonometry", Creditos=4,},
                new Curso{ CursoId=2021, Titulo="Composition", Creditos=3,},
                new Curso{ CursoId=2042, Titulo="Literature", Creditos=4,}
            };

            Cursos.ForEach(c => context.Cursos.Add(c));

            context.SaveChanges();

            var Inscripciones = new List<Inscripcion>
            {
                new Inscripcion{ EstudianteId=1, CursoId=1050, Nota=Nota.A},
                new Inscripcion{ EstudianteId=1, CursoId=4022, Nota=Nota.C},
                new Inscripcion{ EstudianteId=1, CursoId=4041, Nota=Nota.B},
                new Inscripcion{ EstudianteId=2, CursoId=1045, Nota=Nota.B},
                new Inscripcion{ EstudianteId=2, CursoId=3141, Nota=Nota.F},
                new Inscripcion{ EstudianteId=2, CursoId=2021, Nota=Nota.F},
                new Inscripcion{ EstudianteId=3, CursoId=1050,},
                new Inscripcion{ EstudianteId=4, CursoId=1050,},
                new Inscripcion{ EstudianteId=4, CursoId=4022, Nota=Nota.F},
                new Inscripcion{ EstudianteId=5, CursoId=4041, Nota=Nota.C},
                new Inscripcion{ EstudianteId=6, CursoId=1045},
                new Inscripcion{ EstudianteId=7, CursoId=3141, Nota=Nota.A},
            };

            Inscripciones.ForEach(i => context.Inscripciones.Add(i));

            context.SaveChanges();
        }
    }
}