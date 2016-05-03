namespace MVCTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployees : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkReports", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.WorkReports", new[] { "UserId" });
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Group = c.Int(nullable: false),
                        BankName = c.Int(nullable: false),
                        SortCode = c.String(),
                        Account = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.WorkReports", "EmplyeeId", c => c.Int(nullable: false));
            AddColumn("dbo.WorkReports", "Employee_Id", c => c.Int());
            CreateIndex("dbo.WorkReports", "Employee_Id");
            AddForeignKey("dbo.WorkReports", "Employee_Id", "dbo.Employees", "Id");
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.AspNetUsers", "Group");
            DropColumn("dbo.AspNetUsers", "BankName");
            DropColumn("dbo.AspNetUsers", "SortCode");
            DropColumn("dbo.AspNetUsers", "Account");
            DropColumn("dbo.WorkReports", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkReports", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Account", c => c.String());
            AddColumn("dbo.AspNetUsers", "SortCode", c => c.String());
            AddColumn("dbo.AspNetUsers", "BankName", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Group", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 60));
            DropForeignKey("dbo.WorkReports", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.WorkReports", new[] { "Employee_Id" });
            DropIndex("dbo.Employees", new[] { "IsDeleted" });
            DropColumn("dbo.WorkReports", "Employee_Id");
            DropColumn("dbo.WorkReports", "EmplyeeId");
            DropTable("dbo.Employees");
            CreateIndex("dbo.WorkReports", "UserId");
            AddForeignKey("dbo.WorkReports", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
