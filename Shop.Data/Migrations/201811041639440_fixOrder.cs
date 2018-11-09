namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixOrder : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "Quantity", c => c.String());
        }
    }
}
