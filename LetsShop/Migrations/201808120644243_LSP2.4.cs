namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerDetails", "AccessToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerDetails", "AccessToken");
        }
    }
}
