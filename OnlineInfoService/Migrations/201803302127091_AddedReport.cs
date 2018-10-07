namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Date = c.DateTime(nullable: false),
                        MemberId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId)
                .Index(t => t.MemberId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reports", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Reports", "MemberId", "dbo.Members");
            DropIndex("dbo.Reports", new[] { "SubjectId" });
            DropIndex("dbo.Reports", new[] { "MemberId" });
            DropTable("dbo.Reports");
        }
    }
}
