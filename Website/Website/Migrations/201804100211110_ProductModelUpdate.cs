namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Size", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Products", "CategoryId", c => c.Byte(nullable: false));
            AddColumn("dbo.Products", "NumberInStock", c => c.Byte(nullable: false));
            DropTable("dbo.ProductDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Size = c.String(nullable: false, maxLength: 255),
                        CategoryId = c.Byte(nullable: false),
                        NumberInStock = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Products", "NumberInStock");
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "Size");
        }
    }
}
