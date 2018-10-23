namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP43 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductDetails", "CategoryName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductDetails", "CategoryName", c => c.String());
        }
    }
}
