namespace Website.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCart : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[Carts]([User], [Contents]) VALUES('admin@497shirts.com', NULL)");
        }
        
        public override void Down()
        {
        }
    }
}
