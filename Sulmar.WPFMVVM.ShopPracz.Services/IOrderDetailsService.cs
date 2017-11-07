using Sulmar.WPFMVVM.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Services
{
    public interface IOrderDetailsService
    {
        ICollection<OrderDetail> Get(int orderId);
    }
}
