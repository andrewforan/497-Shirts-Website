namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductModel8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Size", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Size", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
