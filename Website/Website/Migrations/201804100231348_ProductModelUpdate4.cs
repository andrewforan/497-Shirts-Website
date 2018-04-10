namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModelUpdate4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ParentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ParentID");
        }
    }
}
