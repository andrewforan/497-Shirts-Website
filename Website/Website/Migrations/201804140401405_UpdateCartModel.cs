namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCartModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carts", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
