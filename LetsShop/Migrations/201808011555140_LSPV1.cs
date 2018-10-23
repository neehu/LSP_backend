namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSPV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryDetails",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CatrgaoryName = c.String(),
                        NumberOfProducts = c.Int(nullable: false),
                        CategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.CustomerDetails",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        EmailAddress = c.String(),
                        PhoneNumber = c.Long(nullable: false),
                        City = c.String(),
                        Address = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.CustomerShoppingDetails",
                c => new
                    {
                        CustomerShoppingID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerShoppingID);
            
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        CategoryID = c.Int(nullable: false),
                        ProductDescription = c.String(),
                        ProductPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductDetails");
            DropTable("dbo.CustomerShoppingDetails");
            DropTable("dbo.CustomerDetails");
            DropTable("dbo.CategoryDetails");
        }
    }
}
