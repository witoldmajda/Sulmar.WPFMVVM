namespace Sulmar.WPFMVVM.ShopPracz.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeightToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Weight", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Weight");
        }
    }
}
