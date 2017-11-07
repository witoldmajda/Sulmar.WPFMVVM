using System;
using System.Collections.Generic;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Models
{
    public class OrderDetail : Base
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Amount
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }

        public int OrderId { get; set; }
    }
}
