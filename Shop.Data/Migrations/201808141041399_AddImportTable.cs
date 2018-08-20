namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImportTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImportDetails",
                c => new
                    {
                        ImportID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.String(),
                    })
                .PrimaryKey(t => new { t.ImportID, t.ProductID })
                .ForeignKey("dbo.Imports", t => t.ImportID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ImportID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Imports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdateddBy = c.String(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImportDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ImportDetails", "ImportID", "dbo.Imports");
            DropIndex("dbo.ImportDetails", new[] { "ProductID" });
            DropIndex("dbo.ImportDetails", new[] { "ImportID" });
            DropTable("dbo.Imports");
            DropTable("dbo.ImportDetails");
        }
    }
}
