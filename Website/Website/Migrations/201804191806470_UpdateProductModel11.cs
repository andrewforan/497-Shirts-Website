namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductModel11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ImageUploadBytes", c => c.Binary(nullable: false));
            AlterColumn("dbo.Products", "ImageMimeType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ImageMimeType", c => c.String());
            AlterColumn("dbo.Products", "ImageUploadBytes", c => c.Binary());
        }
    }
}
