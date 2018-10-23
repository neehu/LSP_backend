namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSPV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryDetails", "CategoryName", c => c.String());
            DropColumn("dbo.CategoryDetails", "CatrgaoryName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoryDetails", "CatrgaoryName", c => c.String());
            DropColumn("dbo.CategoryDetails", "CategoryName");
        }
    }
}
