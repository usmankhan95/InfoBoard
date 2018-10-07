namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingEntriesFromEvents : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Events WHERE Id = 1");
            Sql("DELETE FROM Events WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
