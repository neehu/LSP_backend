namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP29 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CustomerShoppingDetails");
            AddColumn("dbo.ProductDetails", "CustomerShoppingDetails_CustomerID", c => c.Int());
            AlterColumn("dbo.CustomerShoppingDetails", "CustomerID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CustomerShoppingDetails", "CustomerID");
            CreateIndex("dbo.ProductDetails", "CustomerShoppingDetails_CustomerID");
            AddForeignKey("dbo.ProductDetails", "CustomerShoppingDetails_CustomerID", "dbo.CustomerShoppingDetails", "CustomerID");
            DropColumn("dbo.CustomerShoppingDetails", "CustomerShoppingID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerShoppingDetails", "CustomerShoppingID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.ProductDetails", "CustomerShoppingDetails_CustomerID", "dbo.CustomerShoppingDetails");
            DropIndex("dbo.ProductDetails", new[] { "CustomerShoppingDetails_CustomerID" });
            DropPrimaryKey("dbo.CustomerShoppingDetails");
            AlterColumn("dbo.CustomerShoppingDetails", "CustomerID", c => c.Int(nullable: false));
            DropColumn("dbo.ProductDetails", "CustomerShoppingDetails_CustomerID");
            AddPrimaryKey("dbo.CustomerShoppingDetails", "CustomerShoppingID");
        }
    }
}
