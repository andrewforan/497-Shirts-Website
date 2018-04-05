namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreProductDetails : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProductDetails (ProductID, Size, CategoryId, NumberInStock) VALUES (2, 'Small', 0, 20)");
            Sql("INSERT INTO ProductDetails (ProductID, Size, CategoryId, NumberInStock) VALUES (2, 'Medium', 0, 20)");
            Sql("INSERT INTO ProductDetails (ProductID, Size, CategoryId, NumberInStock) VALUES (2, 'Large', 0, 20)");
            Sql("INSERT INTO ProductDetails (ProductID, Size, CategoryId, NumberInStock) VALUES (2, 'Extra Large', 0, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
