namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingSubjectsAgain : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Subjects (Name) VALUES ('Accounting')");
            Sql("INSERT INTO Subjects (Name) VALUES ('Business')");
            Sql("INSERT INTO Subjects (Name) VALUES ('Computer Science')");
            Sql("INSERT INTO Subjects (Name) VALUES ('English')");
            Sql("INSERT INTO Subjects (Name) VALUES ('Law')");
            Sql("INSERT INTO Subjects (Name) VALUES ('Engineering')");
            Sql("INSERT INTO Subjects (Name) VALUES ('Politics')");
            Sql("INSERT INTO Subjects (Name) VALUES ('Mathematics')");
        }
        
        public override void Down()
        {
        }
    }
}
