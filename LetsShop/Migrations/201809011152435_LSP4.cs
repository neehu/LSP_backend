namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP4 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ProductDetails", "CategoryID");
            AddForeignKey("dbo.ProductDetails", "CategoryID", "dbo.CategoryDetails", "CategoryID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDetails", "CategoryID", "dbo.CategoryDetails");
            DropIndex("dbo.ProductDetails", new[] { "CategoryID" });
        }
    }
}
