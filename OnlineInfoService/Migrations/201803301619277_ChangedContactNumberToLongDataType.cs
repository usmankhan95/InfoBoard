namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedContactNumberToLongDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "ContactNumber", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "ContactNumber", c => c.Int(nullable: false));
        }
    }
}
