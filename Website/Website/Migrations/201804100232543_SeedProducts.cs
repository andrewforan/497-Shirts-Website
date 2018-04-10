namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedProducts : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[Products] ([Name], [Price], [ImageLink], [Size], [CategoryId], [NumberInStock], [Viewable], [ParentID]) VALUES (N'Gildan Men''s Classic T-Shirt', CAST(19.99 AS Decimal(18, 2)), N'https://i.imgur.com/WdFVNkT.png', N'Small', 1, 20, 0, 1)                  
INSERT INTO [dbo].[Products] ([Name], [Price], [ImageLink], [Size], [CategoryId], [NumberInStock], [Viewable], [ParentID]) VALUES (N'Gildan Men''s Classic T-Shirt', CAST(19.99 AS Decimal(18, 2)), N'https://i.imgur.com/WdFVNkT.png', N'Medium', 1, 20, 0, 1)
INSERT INTO [dbo].[Products] ([Name], [Price], [ImageLink], [Size], [CategoryId], [NumberInStock], [Viewable], [ParentID]) VALUES (N'Gildan Men''s Classic T-Shirt', CAST(19.99 AS Decimal(18, 2)), N'https://i.imgur.com/WdFVNkT.png', N'Large', 1, 20, 0, 1)
INSERT INTO [dbo].[Products] ([Name], [Price], [ImageLink], [Size], [CategoryId], [NumberInStock], [Viewable], [ParentID]) VALUES (N'Gildan Men''s Classic T-Shirt', CAST(19.99 AS Decimal(18, 2)), N'https://i.imgur.com/WdFVNkT.png', N'Extra Large', 1, 20, 0, 1)     


INSERT INTO[dbo].[Products]([Name], [Price], [ImageLink], [Size], [CategoryId], [NumberInStock], [Viewable], [ParentID]) VALUES(N'Tilted Towers T-Shirt', CAST(14.99 AS Decimal(18, 2)), N'https://i.imgur.com/fRHFwfq.png', N'', 0, 0, 1, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
