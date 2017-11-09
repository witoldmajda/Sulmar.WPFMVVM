namespace Sulmar.WPFMVVM.ShopPracz.DbServices.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sulmar.WPFMVVM.ShopPracz.DbServices.ShopPraczContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Sulmar.WPFMVVM.ShopPracz.DbServices.ShopPraczContext";
        }

        protected override void Seed(Sulmar.WPFMVVM.ShopPracz.DbServices.ShopPraczContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
