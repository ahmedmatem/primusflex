namespace MVCTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeekNumberInWorkReports : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkReports", "WeekNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkReports", "WeekNumber");
        }
    }
}
