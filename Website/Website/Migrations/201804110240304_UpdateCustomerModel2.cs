namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerModel2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Name");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
