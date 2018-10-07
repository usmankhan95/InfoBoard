namespace OnlineInfoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'02d5a508-f563-461a-9103-856fa44c27c5', N'admin@infoboard.co.uk', 0, N'AMnfyW2RDpUDWHlJyW5fydbyJFPDTz6Ykf0m8oYEr78G/u0eL1CD11Cg8xRkPrS08Q==', N'f1087a77-95ff-42d4-8426-9ee758503242', NULL, 0, 0, NULL, 1, 0, N'admin@infoboard.co.uk')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd0e33f33-2f00-47b7-90ef-b1f54bfaba78', N'AdminManager')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'02d5a508-f563-461a-9103-856fa44c27c5', N'd0e33f33-2f00-47b7-90ef-b1f54bfaba78')

");


        }
        
        public override void Down()
        {
        }
    }
}
