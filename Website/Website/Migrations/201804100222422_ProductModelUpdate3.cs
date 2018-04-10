namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModelUpdate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "NumberInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "NumberInStock");
        }
    }
}
