namespace Universidad_ISI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEstudiante : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Estudiante", "Apellidos", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Estudiante", "Names", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Estudiante", "Names", c => c.String(maxLength: 50));
            AlterColumn("dbo.Estudiante", "Apellidos", c => c.String(maxLength: 50));
        }
    }
}
