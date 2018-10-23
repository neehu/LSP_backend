namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDetails", "CustomerShoppingDetails_CustomerShoppingID", c => c.Int());
            CreateIndex("dbo.ProductDetails", "CustomerShoppingDetails_CustomerShoppingID");
            AddForeignKey("dbo.ProductDetails", "CustomerShoppingDetails_CustomerShoppingID", "dbo.CustomerShoppingDetails", "CustomerShoppingID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDetails", "CustomerShoppingDetails_CustomerShoppingID", "dbo.CustomerShoppingDetails");
            DropIndex("dbo.ProductDetails", new[] { "CustomerShoppingDetails_CustomerShoppingID" });
            DropColumn("dbo.ProductDetails", "CustomerShoppingDetails_CustomerShoppingID");
        }
    }
}
