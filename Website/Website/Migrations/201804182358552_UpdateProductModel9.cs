namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductModel9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageUploadBytes", c => c.Binary());
            DropColumn("dbo.Products", "ImageLink");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImageLink", c => c.String(nullable: false));
            DropColumn("dbo.Products", "ImageUploadBytes");
        }
    }
}
