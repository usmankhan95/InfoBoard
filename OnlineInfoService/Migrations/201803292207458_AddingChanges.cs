namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "EventDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "Date");
        }
    }
}
