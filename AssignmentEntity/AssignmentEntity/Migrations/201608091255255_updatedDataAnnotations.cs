namespace AssignmentEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assignments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Teachers", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
            AlterColumn("dbo.Assignments", "Name", c => c.String());
        }
    }
}
