namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProducts1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO[dbo].[Products]([Name], [Price], [ImageLink], [Size], [CategoryId], [NumberInStock], [Viewable], [ParentID]) VALUES(N'Tilted Towers T-Shirt', CAST(14.99 AS Decimal(18, 2)), N'https://i.imgur.com/fRHFwfq.png', N'Small', 1, 20, 0, 18)
INSERT INTO[dbo].[Products]([Name], [Price], [ImageLink], [Size], [CategoryId], [NumberInStock], [Viewable], [ParentID]) VALUES(N'Tilted Towers T-Shirt', CAST(14.99 AS Decimal(18, 2)), N'https://i.imgur.com/fRHFwfq.png', N'Medium', 1, 20, 0, 18)
INSERT INTO[dbo].[Products]([Name], [Price], [ImageLink], [Size], [CategoryId], [NumberInStock], [Viewable], [ParentID]) VALUES(N'Tilted Towers T-Shirt', CAST(14.99 AS Decimal(18, 2)), N'https://i.imgur.com/fRHFwfq.png', N'Large', 1, 20, 0, 18)
INSERT INTO[dbo].[Products]([Name], [Price], [ImageLink], [Size], [CategoryId], [NumberInStock], [Viewable], [ParentID]) VALUES(N'Tilted Towers T-Shirt', CAST(14.99 AS Decimal(18, 2)), N'https://i.imgur.com/fRHFwfq.png', N'Extra Large', 1, 20, 0, 18)");
        }
        
        public override void Down()
        {
        }
    }
}
