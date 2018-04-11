namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerModel6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CardCVV", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CardCVV");
        }
    }
}
