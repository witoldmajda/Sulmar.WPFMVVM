using System;
using System.Collections.Generic;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Models
{
    public class OrderDetail : Base
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        private int _quantity;

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Amount));
            }
        }

        private decimal _unitPrice;

        public decimal UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Amount));
            }
        }

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
