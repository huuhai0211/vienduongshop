namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        WarehouseID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        MaximumQuantity = c.Int(nullable: false),
                        Note = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.WarehouseID, cascadeDelete: true)
                .Index(t => t.WarehouseID)
                .Index(t => t.ProductID);
            
            AddColumn("dbo.Warehouses", "Manager", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "WarehouseID", "dbo.Warehouses");
            DropForeignKey("dbo.Locations", "ProductID", "dbo.Products");
            DropIndex("dbo.Locations", new[] { "ProductID" });
            DropIndex("dbo.Locations", new[] { "WarehouseID" });
            DropColumn("dbo.Warehouses", "Manager");
            DropTable("dbo.Locations");
        }
    }
}
