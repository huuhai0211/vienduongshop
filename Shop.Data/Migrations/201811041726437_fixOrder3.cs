namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixOrder3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "CustomerMessage", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CustomerMessage", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
