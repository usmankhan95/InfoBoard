namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedContactNumberToStringDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "ContactNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "ContactNumber", c => c.Long(nullable: false));
        }
    }
}
