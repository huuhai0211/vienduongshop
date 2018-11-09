namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixUpdateImport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Imports", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Imports", "UpdatedDate", c => c.DateTime());
            DropColumn("dbo.Imports", "UpdateddBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Imports", "UpdateddBy", c => c.String(nullable: false));
            AlterColumn("dbo.Imports", "UpdatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Imports", "UpdatedBy");
        }
    }
}
