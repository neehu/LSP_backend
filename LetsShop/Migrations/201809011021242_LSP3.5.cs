namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP35 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerShoppingDetails", "Product_ProductID", "dbo.ProductDetails");
            DropForeignKey("dbo.ProductDetails", "CustomerShoppingDetails_CustomerID", "dbo.CustomerShoppingDetails");
            DropIndex("dbo.CustomerShoppingDetails", new[] { "Product_ProductID" });
            DropIndex("dbo.ProductDetails", new[] { "CustomerShoppingDetails_CustomerID" });
            AddColumn("dbo.CustomerShoppingDetails", "ProductsListID", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerShoppingDetails", "Product_ProductID");
            DropColumn("dbo.ProductDetails", "CustomerShoppingDetails_CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductDetails", "CustomerShoppingDetails_CustomerID", c => c.Int());
            AddColumn("dbo.CustomerShoppingDetails", "Product_ProductID", c => c.Int());
            DropColumn("dbo.CustomerShoppingDetails", "ProductsListID");
            CreateIndex("dbo.ProductDetails", "CustomerShoppingDetails_CustomerID");
            CreateIndex("dbo.CustomerShoppingDetails", "Product_ProductID");
            AddForeignKey("dbo.ProductDetails", "CustomerShoppingDetails_CustomerID", "dbo.CustomerShoppingDetails", "CustomerID");
            AddForeignKey("dbo.CustomerShoppingDetails", "Product_ProductID", "dbo.ProductDetails", "ProductID");
        }
    }
}
