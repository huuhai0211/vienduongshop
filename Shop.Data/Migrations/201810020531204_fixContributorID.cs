namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixContributorID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "BusinessID", "dbo.Contributors");
            DropPrimaryKey("dbo.Contributors");
            AlterColumn("dbo.Contributors", "ID_Business", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Contributors", "ID_Business");
            AddForeignKey("dbo.Products", "BusinessID", "dbo.Contributors", "ID_Business");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "BusinessID", "dbo.Contributors");
            DropPrimaryKey("dbo.Contributors");
            AlterColumn("dbo.Contributors", "ID_Business", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Contributors", "ID_Business");
            AddForeignKey("dbo.Products", "BusinessID", "dbo.Contributors", "ID_Business");
        }
    }
}
