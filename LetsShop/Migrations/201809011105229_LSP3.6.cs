namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP36 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductLists",
                c => new
                    {
                        ProductsListID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductsListID);
            
            DropTable("dbo.CustomerShoppingDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerShoppingDetails",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        ProductsListID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            DropTable("dbo.ProductLists");
        }
    }
}
