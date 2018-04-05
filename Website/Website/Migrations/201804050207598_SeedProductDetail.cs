namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedProductDetail : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProductDetails (ProductID, Size, CategoryId, NumberInStock) VALUES (1, 'Small', 0, 20)");
            Sql("INSERT INTO ProductDetails (ProductID, Size, CategoryId, NumberInStock) VALUES (1, 'Medium', 0, 20)");
            Sql("INSERT INTO ProductDetails (ProductID, Size, CategoryId, NumberInStock) VALUES (1, 'Large', 0, 20)");
            Sql("INSERT INTO ProductDetails (ProductID, Size, CategoryId, NumberInStock) VALUES (1, 'Extra Large', 0, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
