namespace Universidad_ISI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthOnNames : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Estudiante", "Apellidos", c => c.String(maxLength: 50));
            AlterColumn("dbo.Estudiante", "Nombres", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Estudiante", "Nombres", c => c.String());
            AlterColumn("dbo.Estudiante", "Apellidos", c => c.String());
        }
    }
}
