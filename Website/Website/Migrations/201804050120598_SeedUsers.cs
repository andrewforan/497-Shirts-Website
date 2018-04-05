namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5586e419-6709-4b8c-a2be-a0ae62078524', N'test@test.com', 0, N'AH9z+WxWyrHxdADuRTJsFRWPQTc+gmcTK717JGk8BRYIRUNYDK1noL/2/pw7YEuRVA==', N'd68aa877-7afb-4856-a7f0-07a17e64407f', NULL, 0, 0, NULL, 1, 0, N'test@test.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ad82a52b-7ba6-455f-8468-0a06a0aede55', N'admin@497shirts.com', 0, N'AMNitTh/RxRJ2XCGN5laZcFgIUH9VDufQj5u+gUXCsNtCdsp5/O0q63YaeoXi+ykUw==', N'618a6723-0a94-42f7-98b1-59f358f7c692', NULL, 0, 0, NULL, 1, 0, N'admin@497shirts.com')


INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b0e08c28-d72e-4886-b3c9-96a60de0ef93', N'Admin')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ad82a52b-7ba6-455f-8468-0a06a0aede55', N'b0e08c28-d72e-4886-b3c9-96a60de0ef93')
");
        }
        
        public override void Down()
        {
        }
    }
}
