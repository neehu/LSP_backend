namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP44 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerDetails", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerDetails", "Country", c => c.String());
        }
    }
}
