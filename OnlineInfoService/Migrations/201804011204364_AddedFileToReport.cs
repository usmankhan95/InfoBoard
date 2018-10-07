namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFileToReport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "File", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "File");
        }
    }
}
