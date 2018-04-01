namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Size", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Products", "CategoryId", c => c.Byte(nullable: false));
            AddColumn("dbo.Products", "NumberInStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "NumberInStock");
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Products", "Size");
        }
    }
}
