namespace MVCTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnrequiredName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 60));
        }
    }
}
