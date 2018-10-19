namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWarehouseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Note = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Warehouses");
        }
    }
}
