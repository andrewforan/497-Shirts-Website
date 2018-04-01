namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProducts1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "GroupId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "GroupId");
        }
    }
}
