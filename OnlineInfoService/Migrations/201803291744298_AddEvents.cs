namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEvents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        EventDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Members", "Event_Id", c => c.Int());
            AddColumn("dbo.Members", "EventId_Id", c => c.Int());
            CreateIndex("dbo.Members", "Event_Id");
            CreateIndex("dbo.Members", "EventId_Id");
            AddForeignKey("dbo.Members", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Members", "EventId_Id", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "EventId_Id", "dbo.Events");
            DropForeignKey("dbo.Members", "Event_Id", "dbo.Events");
            DropIndex("dbo.Members", new[] { "EventId_Id" });
            DropIndex("dbo.Members", new[] { "Event_Id" });
            DropColumn("dbo.Members", "EventId_Id");
            DropColumn("dbo.Members", "Event_Id");
            DropTable("dbo.Events");
        }
    }
}
