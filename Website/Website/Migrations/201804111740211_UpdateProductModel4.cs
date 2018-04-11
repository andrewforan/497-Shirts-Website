namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductModel4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "NumberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "NumberInStock", c => c.Byte(nullable: false));
        }
    }
}
