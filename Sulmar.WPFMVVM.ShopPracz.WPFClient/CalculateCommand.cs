using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulmar.WPFMVVM.ShopPracz.WPFClient
{
    class CalculateCommand
    {
        private decimal amount;

        public CalculateCommand(decimal amount)
        {
            this.amount = amount;
        }
    }
}
