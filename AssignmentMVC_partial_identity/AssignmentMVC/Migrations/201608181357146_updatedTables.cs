namespace AssignmentMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "city_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "city_Id");
            AddForeignKey("dbo.AspNetUsers", "city_Id", "dbo.Cities", "Id");
            DropTable("dbo.People");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        City = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AspNetUsers", "city_Id", "dbo.Cities");
            DropIndex("dbo.AspNetUsers", new[] { "city_Id" });
            DropColumn("dbo.AspNetUsers", "city_Id");
        }
    }
}
