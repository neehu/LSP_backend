namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP42 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductDetails", "CustomerDetails_CustomerID", "dbo.CustomerDetails");
            DropIndex("dbo.ProductDetails", new[] { "CustomerDetails_CustomerID" });
            DropColumn("dbo.ProductDetails", "CustomerDetails_CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductDetails", "CustomerDetails_CustomerID", c => c.Int());
            CreateIndex("dbo.ProductDetails", "CustomerDetails_CustomerID");
            AddForeignKey("dbo.ProductDetails", "CustomerDetails_CustomerID", "dbo.CustomerDetails", "CustomerID");
        }
    }
}
