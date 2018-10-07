namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingEventsWithTestDataAgain : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Events (Name, SubjectId, Description, Date) VALUES ('Test', 2, 'Test description', '20180320')");
            Sql("INSERT INTO Events (Name, SubjectId, Description, Date) VALUES ('Test1', 4, 'Test description1', '20190310')");
            Sql("INSERT INTO Events (Name, SubjectId, Description, Date) VALUES ('Test2', 3, 'Test description2', '20181120')");
            Sql("INSERT INTO Events (Name, SubjectId, Description, Date) VALUES ('Test3', 6, 'Test description3', '20181120')");
        }
        
        public override void Down()
        {
        }
    }
}
