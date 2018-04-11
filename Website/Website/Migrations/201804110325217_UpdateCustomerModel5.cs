namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerModel5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "CardCCV");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CardCCV", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
