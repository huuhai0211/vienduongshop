namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImportPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImportDetails", "WarehouseId", c => c.Int(nullable: false));
            AddColumn("dbo.ImportDetails", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.ImportDetails", "WarehouseId");
            AddForeignKey("dbo.ImportDetails", "WarehouseId", "dbo.Warehouses", "ID", cascadeDelete: true);
            DropColumn("dbo.OrderDetails", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.ImportDetails", "WarehouseId", "dbo.Warehouses");
            DropIndex("dbo.ImportDetails", new[] { "WarehouseId" });
            DropColumn("dbo.ImportDetails", "Price");
            DropColumn("dbo.ImportDetails", "WarehouseId");
        }
    }
}
