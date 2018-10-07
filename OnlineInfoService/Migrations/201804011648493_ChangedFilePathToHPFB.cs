namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedFilePathToHPFB : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reports", "FilePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reports", "FilePath", c => c.String());
        }
    }
}
