namespace MVCTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToReports : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkReports", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkReports", "Date");
        }
    }
}
