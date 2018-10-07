namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeChangesToMembers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "WorkLocation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "WorkLocation", c => c.String());
        }
    }
}
