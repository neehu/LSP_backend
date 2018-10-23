namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP48 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductLists", "ListOfProducts", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductLists", "ListOfProducts");
        }
    }
}
