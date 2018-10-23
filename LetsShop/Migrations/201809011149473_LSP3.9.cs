namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP39 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDetails", "CustomerDetails_CustomerID", c => c.Int());
            CreateIndex("dbo.ProductDetails", "CustomerDetails_CustomerID");
            CreateIndex("dbo.ProductLists", "CustomerID");
            AddForeignKey("dbo.ProductDetails", "CustomerDetails_CustomerID", "dbo.CustomerDetails", "CustomerID");
            AddForeignKey("dbo.ProductLists", "CustomerID", "dbo.CustomerDetails", "CustomerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductLists", "CustomerID", "dbo.CustomerDetails");
            DropForeignKey("dbo.ProductDetails", "CustomerDetails_CustomerID", "dbo.CustomerDetails");
            DropIndex("dbo.ProductLists", new[] { "CustomerID" });
            DropIndex("dbo.ProductDetails", new[] { "CustomerDetails_CustomerID" });
            DropColumn("dbo.ProductDetails", "CustomerDetails_CustomerID");
        }
    }
}
