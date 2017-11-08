using Sulmar.WPFMVVM.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Services
{
    public interface IFiltersService
    {
        Filter Get(int id);

        void Update(IFiltersService filter);


    }


}
