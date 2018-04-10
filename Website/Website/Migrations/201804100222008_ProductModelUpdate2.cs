namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModelUpdate2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "NumberInStock", c => c.Byte(nullable: false));
        }
    }
}
