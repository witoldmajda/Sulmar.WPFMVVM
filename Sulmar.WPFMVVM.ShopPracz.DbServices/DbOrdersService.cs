using Sulmar.WPFMVVM.ShopPracz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sulmar.WPFMVVM.ShopPracz.Models;

namespace Sulmar.WPFMVVM.ShopPracz.DbServices
{
    public class DbOrdersService : IOrdersService
    {
        public ICollection<Order> Get()
        {
            var context = new ShopPraczContext(); //twożymy instancję klasy Context

            var orders = context.Orders.ToList();  //zapytanie do bazy zwracające wyniki 

            return orders;
        }
    }
}
