namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        Contents = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carts");
        }
    }
}
