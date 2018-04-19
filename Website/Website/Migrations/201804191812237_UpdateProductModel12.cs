namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductModel12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ImageUploadBytes", c => c.Binary());
            AlterColumn("dbo.Products", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ImageMimeType", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ImageUploadBytes", c => c.Binary(nullable: false));
        }
    }
}
