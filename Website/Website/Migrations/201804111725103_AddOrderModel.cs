namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 255),
                        PhoneNumber = c.String(nullable: false, maxLength: 255),
                        ItemsOrdered = c.String(maxLength: 255),
                        BillName = c.String(nullable: false, maxLength: 255),
                        BillAddress = c.String(nullable: false, maxLength: 255),
                        BillCity = c.String(nullable: false, maxLength: 255),
                        BillState = c.String(nullable: false, maxLength: 255),
                        BillZip = c.String(nullable: false, maxLength: 255),
                        ShipName = c.String(nullable: false, maxLength: 255),
                        ShipAddress = c.String(nullable: false, maxLength: 255),
                        ShipCity = c.String(nullable: false, maxLength: 255),
                        ShipState = c.String(nullable: false, maxLength: 255),
                        ShipZip = c.String(nullable: false, maxLength: 255),
                        CardNumber = c.String(nullable: false, maxLength: 255),
                        CardName = c.String(nullable: false, maxLength: 255),
                        CardExpirartion = c.String(nullable: false, maxLength: 255),
                        CardCVV = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
