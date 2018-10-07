namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedFilePathCleanUp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reports", "FilePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reports", "FilePath", c => c.String(nullable: false));
        }
    }
}
