namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModelUpdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Viewable", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Viewable");
        }
    }
}
