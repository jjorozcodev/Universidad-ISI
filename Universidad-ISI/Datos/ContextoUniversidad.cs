using Universidad_ISI.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Universidad_ISI.Datos
{
    public class ContextoUniversidad : DbContext
    {
        public ContextoUniversidad() : base("ContextoUniversidad")
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Departamento> Departmentos { get; set; }
        public DbSet<Instructor> Instructores { get; set; }
        public DbSet<OficinaAsignada> OficinasAsignadas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Curso>()
             .HasMany(c => c.Instructores).WithMany(i => i.Cursos)
             .Map(t => t.MapLeftKey("CourseID")
                 .MapRightKey("InstructorID")
                 .ToTable("CourseInstructor"));
        }
    }
}