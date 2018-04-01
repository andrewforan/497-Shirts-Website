namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageToProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImageLink");
        }
    }
}
