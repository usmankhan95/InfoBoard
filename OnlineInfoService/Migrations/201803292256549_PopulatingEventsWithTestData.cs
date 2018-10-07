namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingEventsWithTestData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Events (Name, SubjectId, Description, Date) VALUES ('Test', 2, 'Test description', '20180320')");
            Sql("INSERT INTO Events (Name, SubjectId, Description, Date) VALUES ('Test1', 4, 'Test description1', '20190310')");
        }
        
        public override void Down()
        {
        }
    }
}
