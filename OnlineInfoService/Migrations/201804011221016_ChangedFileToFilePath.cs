namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedFileToFilePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "FilePath", c => c.String(nullable: false));
            DropColumn("dbo.Reports", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "File", c => c.Binary(nullable: false));
            DropColumn("dbo.Reports", "FilePath");
        }
    }
}
