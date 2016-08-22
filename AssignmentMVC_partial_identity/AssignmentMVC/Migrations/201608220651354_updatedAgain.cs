namespace AssignmentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedAgain : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Cities", name: "country_Id", newName: "Countries_Id");
            RenameIndex(table: "dbo.Cities", name: "IX_country_Id", newName: "IX_Countries_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Cities", name: "IX_Countries_Id", newName: "IX_country_Id");
            RenameColumn(table: "dbo.Cities", name: "Countries_Id", newName: "country_Id");
        }
    }
}
