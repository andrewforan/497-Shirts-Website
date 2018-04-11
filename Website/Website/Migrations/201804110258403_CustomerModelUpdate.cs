namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "PhoneNumber");
            DropColumn("dbo.Customers", "BillName");
            DropColumn("dbo.Customers", "BillAddress");
            DropColumn("dbo.Customers", "BillCity");
            DropColumn("dbo.Customers", "BillState");
            DropColumn("dbo.Customers", "BillZip");
            DropColumn("dbo.Customers", "ShipName");
            DropColumn("dbo.Customers", "ShipAddress");
            DropColumn("dbo.Customers", "ShipCity");
            DropColumn("dbo.Customers", "ShipState");
            DropColumn("dbo.Customers", "ShipZip");
            DropColumn("dbo.Customers", "CardNumber");
            DropColumn("dbo.Customers", "CardName");
            DropColumn("dbo.Customers", "CardExpirartion");
            DropColumn("dbo.Customers", "CardCCV");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CardCCV", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "CardExpirartion", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "CardName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "CardNumber", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "ShipZip", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "ShipState", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "ShipCity", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "ShipAddress", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "ShipName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "BillZip", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "BillState", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "BillCity", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "BillAddress", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "BillName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "PhoneNumber", c => c.String(maxLength: 255));
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
