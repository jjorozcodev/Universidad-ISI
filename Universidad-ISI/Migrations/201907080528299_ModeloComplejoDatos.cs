namespace Universidad_ISI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloComplejoDatos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50),
                        Presupuesto = c.Decimal(nullable: false, storeType: "money"),
                        FechaInicio = c.DateTime(nullable: false),
                        InstructorID = c.Int(),
                    })
                .PrimaryKey(t => t.DepartamentoId)
                .ForeignKey("dbo.Instructor", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Apellidos = c.String(maxLength: 50),
                        Nombre = c.String(maxLength: 50),
                        FechaContratacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OficinaAsignada",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InstructorID)
                .ForeignKey("dbo.Instructor", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.CourseInstructor",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        InstructorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.InstructorID })
                .ForeignKey("dbo.Curso", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Instructor", t => t.InstructorID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.InstructorID);

            // Create  a department for course to point to.
            Sql("INSERT INTO dbo.Departamento (Nombre, Presupuesto, FechaInicio) VALUES ('Temp', 0.00, GETDATE())");
            //  default value for FK points to department created above.
            AddColumn("dbo.Curso", "DepartamentoId", c => c.Int(nullable: false, defaultValue: 1));

            //AddColumn("dbo.Curso", "DepartamentoId", c => c.Int(nullable: false));

            AlterColumn("dbo.Curso", "Titulo", c => c.String(maxLength: 50));
            CreateIndex("dbo.Curso", "DepartamentoId");
            AddForeignKey("dbo.Curso", "DepartamentoId", "dbo.Departamento", "DepartamentoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseInstructor", "InstructorID", "dbo.Instructor");
            DropForeignKey("dbo.CourseInstructor", "CourseID", "dbo.Curso");
            DropForeignKey("dbo.Curso", "DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.Departamento", "InstructorID", "dbo.Instructor");
            DropForeignKey("dbo.OficinaAsignada", "InstructorID", "dbo.Instructor");
            DropIndex("dbo.CourseInstructor", new[] { "InstructorID" });
            DropIndex("dbo.CourseInstructor", new[] { "CourseID" });
            DropIndex("dbo.OficinaAsignada", new[] { "InstructorID" });
            DropIndex("dbo.Departamento", new[] { "InstructorID" });
            DropIndex("dbo.Curso", new[] { "DepartamentoId" });
            AlterColumn("dbo.Curso", "Titulo", c => c.String());
            DropColumn("dbo.Curso", "DepartamentoId");
            DropTable("dbo.CourseInstructor");
            DropTable("dbo.OficinaAsignada");
            DropTable("dbo.Instructor");
            DropTable("dbo.Departamento");
        }
    }
}
