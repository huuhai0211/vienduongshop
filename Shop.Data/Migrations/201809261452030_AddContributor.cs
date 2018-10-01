namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContributor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contributors",
                c => new
                    {
                        ID_Business = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Alias = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Description = c.String(maxLength: 500),
                        Address = c.String(nullable: false),
                        Phone_Number = c.Int(nullable: false),
                        Email = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID_Business);
            
            AddColumn("dbo.Products", "BusinessID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "BusinessID");
            AddForeignKey("dbo.Products", "BusinessID", "dbo.Contributors", "ID_Business", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "BusinessID", "dbo.Contributors");
            DropIndex("dbo.Products", new[] { "BusinessID" });
            DropColumn("dbo.Products", "BusinessID");
            DropTable("dbo.Contributors");
        }
    }
}
