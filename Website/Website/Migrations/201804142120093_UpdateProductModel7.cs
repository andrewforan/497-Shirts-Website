namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductModel7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Viewable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "ParentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ParentID");
            DropColumn("dbo.Products", "Viewable");
        }
    }
}
