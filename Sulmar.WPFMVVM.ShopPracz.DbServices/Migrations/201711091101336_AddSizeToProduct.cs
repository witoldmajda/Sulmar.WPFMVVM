namespace Sulmar.WPFMVVM.ShopPracz.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSizeToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Size", c => c.String());

            Sql("UPDATE dbo.Products SET Size='M' WHERE Size is null");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Size");
        }
    }
}
