namespace AssignmentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedCity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "city_Id", "dbo.Cities");
            DropIndex("dbo.AspNetUsers", new[] { "city_Id" });
            DropColumn("dbo.AspNetUsers", "city_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "city_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "city_Id");
            AddForeignKey("dbo.AspNetUsers", "city_Id", "dbo.Cities", "Id");
        }
    }
}
