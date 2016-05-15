namespace MVCTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteGroupFromEmployee : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "Group");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Group", c => c.Int(nullable: false));
        }
    }
}
