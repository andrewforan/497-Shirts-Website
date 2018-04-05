namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModelEdits : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "GroupId");
            DropColumn("dbo.Products", "Size");
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "NumberInStock", c => c.Byte(nullable: false));
            AddColumn("dbo.Products", "CategoryId", c => c.Byte(nullable: false));
            AddColumn("dbo.Products", "Size", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Products", "GroupId", c => c.Byte(nullable: false));
        }
    }
}
