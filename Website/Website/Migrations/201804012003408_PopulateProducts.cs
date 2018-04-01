namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProducts : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Products (Name, Price, Size, CategoryId, NumberInStock, ImageLink, GroupId) VALUES ('Gildan Men''s Classic T-Shirt', 19.99, 'Small', 0, 20, 'https://i.imgur.com/WdFVNkT.png', 1)");
            Sql("INSERT INTO Products (Name, Price, Size, CategoryId, NumberInStock, ImageLink, GroupId) VALUES ('Straight Outta Tilted Towers T-Shirt', 14.99, 'Small', 0, 20, 'https://i.imgur.com/fRHFwfq.png', 1)");

        }

        public override void Down()
        {
        }
    }
}
