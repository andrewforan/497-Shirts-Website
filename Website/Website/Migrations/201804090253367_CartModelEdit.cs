namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartModelEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Empty", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "Empty");
        }
    }
}
