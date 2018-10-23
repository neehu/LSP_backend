namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductDetails", "CategoryName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductDetails", "CategoryName");
        }
    }
}
