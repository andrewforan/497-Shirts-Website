namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBaseProducts : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[Products] ([Name], [Price], [ImageLink], [Size], [CategoryId], [NumberInStock], [Viewable], [ParentID]) VALUES (N'Gildan Men''s Classic T-Shirt', CAST(19.99 AS Decimal(18, 2)), N'https://i.imgur.com/WdFVNkT.png', N'Blank', 1, 0, 0, 0)
INSERT INTO [dbo].[Products] ([Name], [Price], [ImageLink], [Size], [CategoryId], [NumberInStock], [Viewable], [ParentID]) VALUES (N'Tilted Towers T-Shirt', CAST(14.99 AS Decimal(18, 2)), N'https://i.imgur.com/fRHFwfq.png', N'Blank', 1, 0, 0, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
