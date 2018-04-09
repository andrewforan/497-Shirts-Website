namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartModelEdit1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carts", "Empty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Empty", c => c.Boolean(nullable: false));
        }
    }
}
