namespace MVCTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorectUserIdtypefrominttostring : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Employees", new[] { "User_Id" });
            DropColumn("dbo.Employees", "UserId");
            RenameColumn(table: "dbo.Employees", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Employees", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "UserId" });
            AlterColumn("dbo.Employees", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Employees", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Employees", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "User_Id");
        }
    }
}
