namespace MVCTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationUserIdtoEmployees : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "User_Id");
            AddForeignKey("dbo.Employees", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "User_Id" });
            DropColumn("dbo.Employees", "User_Id");
            DropColumn("dbo.Employees", "UserId");
        }
    }
}
