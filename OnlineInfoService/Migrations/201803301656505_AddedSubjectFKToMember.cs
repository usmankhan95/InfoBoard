namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSubjectFKToMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "SubjectId");
            AddForeignKey("dbo.Members", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Members", new[] { "SubjectId" });
            DropColumn("dbo.Members", "SubjectId");
        }
    }
}
