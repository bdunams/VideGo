namespace VideGo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'523745c1-b046-4441-9f45-7e63f66e3413', N'guest@vidego.com', 0, N'AAqOu1aWJE2SE4YFvY32YXpSCSRAnNAndwQxfvKpr1ehyLjZRrtCvtftmW9VuhgUzg==', N'a277e87f-3102-47a0-8071-45c215e33859', NULL, 0, 0, NULL, 1, 0, N'guest@vidego.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a1070b7a-c402-4c81-9118-fe8a556b5b64', N'admin@vidego.com', 0, N'AFYUxeIdXkoeykzxG+6TXGJ9GtPwCc6uE2fhTv+/1BNSxEfViM1GFsNxWX0dm+do1g==', N'71ca6965-0753-44d4-a6ea-ff044da57c1c', NULL, 0, 0, NULL, 1, 0, N'admin@vidego.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5b018187-ba08-45d6-8c32-0bb164af04e1', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a1070b7a-c402-4c81-9118-fe8a556b5b64', N'5b018187-ba08-45d6-8c32-0bb164af04e1')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
