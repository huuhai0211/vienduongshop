namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixnullproduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BusinessID", "dbo.Contributors");
            DropIndex("dbo.Products", new[] { "BusinessID" });
            AlterColumn("dbo.Products", "BusinessID", c => c.Int());
            CreateIndex("dbo.Products", "BusinessID");
            AddForeignKey("dbo.Products", "BusinessID", "dbo.Contributors", "ID_Business");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "BusinessID", "dbo.Contributors");
            DropIndex("dbo.Products", new[] { "BusinessID" });
            AlterColumn("dbo.Products", "BusinessID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "BusinessID");
            AddForeignKey("dbo.Products", "BusinessID", "dbo.Contributors", "ID_Business", cascadeDelete: true);
        }
    }
}
