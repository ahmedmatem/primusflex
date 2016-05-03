namespace MVCTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Corectfieldname : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkReports", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.WorkReports", new[] { "Employee_Id" });
            RenameColumn(table: "dbo.WorkReports", name: "Employee_Id", newName: "EmployeeId");
            AlterColumn("dbo.WorkReports", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.WorkReports", "EmployeeId");
            AddForeignKey("dbo.WorkReports", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            DropColumn("dbo.WorkReports", "EmplyeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkReports", "EmplyeeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.WorkReports", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.WorkReports", new[] { "EmployeeId" });
            AlterColumn("dbo.WorkReports", "EmployeeId", c => c.Int());
            RenameColumn(table: "dbo.WorkReports", name: "EmployeeId", newName: "Employee_Id");
            CreateIndex("dbo.WorkReports", "Employee_Id");
            AddForeignKey("dbo.WorkReports", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}
