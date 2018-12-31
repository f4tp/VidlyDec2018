namespace VidlyDec2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersUsingSQL : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'46af8d5f-725f-4c9c-8d4f-ac076c487ab2', N'guest@vidly.com', 0, N'AIfTO1/spN7I2kuAD2/9IF4BwJrxebazcL8S7L3p8LB9UIZZlFZSgyNiCzmTKtinmQ==', N'e881bff5-df9a-4a25-80ff-1dfc70a8855a', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c0ef519e-a9ab-42c2-abcf-2e319cf3ee30', N'admin@vidly.com', 0, N'AN/aq6w2tptSPAPyxS2pXdj4+7FzmHaLGG4nI1JW9SAkyBEIk3Gvc9jCcBpEV4wOnw==', N'7e5c448a-b015-4776-b4fc-6dafd5450531', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                    
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5ed59c53-c5ff-4f40-93f5-8e4b8f26a8df', N'CanManageMovies')


                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c0ef519e-a9ab-42c2-abcf-2e319cf3ee30', N'5ed59c53-c5ff-4f40-93f5-8e4b8f26a8df')



            ");
        }
        
        public override void Down()
        {
        }
    }
}
