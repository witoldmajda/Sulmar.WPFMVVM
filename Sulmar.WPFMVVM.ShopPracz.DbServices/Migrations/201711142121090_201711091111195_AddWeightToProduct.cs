namespace Sulmar.WPFMVVM.ShopPracz.DbServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201711091111195_AddWeightToProduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Weight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Weight", c => c.Single(nullable: false));
        }
    }
}
