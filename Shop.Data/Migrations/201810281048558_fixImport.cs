namespace Shop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixImport : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImportDetails", "ImportID", "dbo.Imports");
            DropPrimaryKey("dbo.Imports");
            AlterColumn("dbo.Imports", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Imports", "ID");
            AddForeignKey("dbo.ImportDetails", "ImportID", "dbo.Imports", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImportDetails", "ImportID", "dbo.Imports");
            DropPrimaryKey("dbo.Imports");
            AlterColumn("dbo.Imports", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Imports", "ID");
            AddForeignKey("dbo.ImportDetails", "ImportID", "dbo.Imports", "ID", cascadeDelete: true);
        }
    }
}
