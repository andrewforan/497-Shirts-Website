namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductDetail : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductDetails");
        }
    }
}
