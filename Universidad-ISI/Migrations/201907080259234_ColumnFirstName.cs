namespace Universidad_ISI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnFirstName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Estudiante", name: "Nombres", newName: "Names");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Estudiante", name: "Names", newName: "Nombres");
        }
    }
}
