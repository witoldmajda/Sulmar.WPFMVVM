using Sulmar.WPFMVVM.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulmar.WPFMVVM.ShopPracz.DbServices
{
    public class ShopPraczContext : DbContext
    {
        public ShopPraczContext()
            :base("ShopPraczConnection")  //wywołujemy konstr bazowy z argumentem jako nazwa w pliku konfig.
        {

        }
        #region DbSets
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        #endregion DbSet
    }
}
