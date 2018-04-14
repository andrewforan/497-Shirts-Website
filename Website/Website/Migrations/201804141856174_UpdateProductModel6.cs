namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductModel6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ImageLink", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Size", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Size", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "ImageLink", c => c.String());
        }
    }
}
