namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubject : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "EventId", "dbo.Events");
            DropIndex("dbo.Members", new[] { "EventId" });
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Events", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "SubjectId");
            AddForeignKey("dbo.Events", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            DropColumn("dbo.Members", "EventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "EventId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Events", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Events", new[] { "SubjectId" });
            DropColumn("dbo.Events", "SubjectId");
            DropTable("dbo.Subjects");
            CreateIndex("dbo.Members", "EventId");
            AddForeignKey("dbo.Members", "EventId", "dbo.Events", "Id", cascadeDelete: true);
        }
    }
}
