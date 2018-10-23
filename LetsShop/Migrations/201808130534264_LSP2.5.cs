namespace LetsShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LSP25 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ToastMessages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Style = c.String(),
                        Dismissed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ToastMessages");
        }
    }
}
