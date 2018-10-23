namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP33 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerShoppingDetails", "Product_ProductID", c => c.Int());
            CreateIndex("dbo.CustomerShoppingDetails", "Product_ProductID");
            AddForeignKey("dbo.CustomerShoppingDetails", "Product_ProductID", "dbo.ProductDetails", "ProductID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerShoppingDetails", "Product_ProductID", "dbo.ProductDetails");
            DropIndex("dbo.CustomerShoppingDetails", new[] { "Product_ProductID" });
            DropColumn("dbo.CustomerShoppingDetails", "Product_ProductID");
        }
    }
}
