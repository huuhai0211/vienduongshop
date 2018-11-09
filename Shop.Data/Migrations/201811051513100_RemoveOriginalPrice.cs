namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOriginalPrice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "OriginalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
