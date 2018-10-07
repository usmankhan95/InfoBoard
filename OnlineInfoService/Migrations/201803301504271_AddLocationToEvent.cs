namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Location");
        }
    }
}
