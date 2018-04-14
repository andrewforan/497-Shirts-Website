namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductModel5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Viewable");
            DropColumn("dbo.Products", "ParentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ParentID", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Viewable", c => c.Boolean(nullable: false));
        }
    }
}
