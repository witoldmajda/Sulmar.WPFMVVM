using Sulmar.WPFMVVM.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Services
{
    public interface IProductsService
    {
        void Add(Product product);

        void Update(Product product);

        void Remove(int id);

        ICollection<Product> Get();

        Product Get(int id);

        Product Get(string name);
    }
}
