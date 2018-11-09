namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixOrder2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Status", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "Status", c => c.Boolean(nullable: false));
        }
    }
}
