namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Size", c => c.String(maxLength: 255));
            DropColumn("dbo.Products", "Viewable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Viewable", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Products", "Size", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
