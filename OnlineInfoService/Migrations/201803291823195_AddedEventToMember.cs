namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEventToMember : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "EventId_Id", "dbo.Events");
            DropForeignKey("dbo.Members", "Event_Id", "dbo.Events");
            DropIndex("dbo.Members", new[] { "Event_Id" });
            DropIndex("dbo.Members", new[] { "EventId_Id" });
            RenameColumn(table: "dbo.Members", name: "Event_Id", newName: "EventId");
            AlterColumn("dbo.Members", "EventId", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "EventId");
            AddForeignKey("dbo.Members", "EventId", "dbo.Events", "Id", cascadeDelete: true);
            DropColumn("dbo.Members", "EventId_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "EventId_Id", c => c.Int());
            DropForeignKey("dbo.Members", "EventId", "dbo.Events");
            DropIndex("dbo.Members", new[] { "EventId" });
            AlterColumn("dbo.Members", "EventId", c => c.Int());
            RenameColumn(table: "dbo.Members", name: "EventId", newName: "Event_Id");
            CreateIndex("dbo.Members", "EventId_Id");
            CreateIndex("dbo.Members", "Event_Id");
            AddForeignKey("dbo.Members", "Event_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Members", "EventId_Id", "dbo.Events", "Id");
        }
    }
}
