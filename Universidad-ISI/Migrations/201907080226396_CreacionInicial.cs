namespace Universidad_ISI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreacionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        CursoId = c.Int(nullable: false),
                        Titulo = c.String(),
                        Creditos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CursoId);
            
            CreateTable(
                "dbo.Inscripcion",
                c => new
                    {
                        InscripcionId = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        EstudianteId = c.Int(nullable: false),
                        Nota = c.Int(),
                    })
                .PrimaryKey(t => t.InscripcionId)
                .ForeignKey("dbo.Curso", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.Estudiante", t => t.EstudianteId, cascadeDelete: true)
                .Index(t => t.CursoId)
                .Index(t => t.EstudianteId);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        EstudianteId = c.Int(nullable: false, identity: true),
                        Apellidos = c.String(),
                        Nombres = c.String(),
                        FechaInscripcion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EstudianteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscripcion", "EstudianteId", "dbo.Estudiante");
            DropForeignKey("dbo.Inscripcion", "CursoId", "dbo.Curso");
            DropIndex("dbo.Inscripcion", new[] { "EstudianteId" });
            DropIndex("dbo.Inscripcion", new[] { "CursoId" });
            DropTable("dbo.Estudiante");
            DropTable("dbo.Inscripcion");
            DropTable("dbo.Curso");
        }
    }
}
