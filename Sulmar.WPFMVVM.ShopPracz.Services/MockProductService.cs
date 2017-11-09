using System;
using System.Collections.Generic;
using System.Text;
using Sulmar.WPFMVVM.ShopPracz.Models;
using System.Linq;

namespace Sulmar.WPFMVVM.ShopPracz.Services
{
    public class MockProductService : IProductsService
    {
        private ICollection<Product> products;

        public MockProductService()
        {
            products = new List<Product>
            {
                new Product {Id = 1, Color = "Red", Name = "Produkt 1", Price = 99.9m},
                new Product {Id = 2, Color = "Blue", Name = "Produkt 2", Price = 49.5m},
                new Product {Id = 3, Color = "Green", Name = "Produkt 3", Price = 79.9m},
                new Product {Id = 4, Color = "Blue", Name = "Produkt 4", Price = 39.9m},
                new Product {Id = 5, Color = "Red", Name = "Produkt 5", Price = 10.0m},
            };
        }

        public void Add(Product product)
        {
            product.Id = products.Max(p => p.Id) + 1;

            products.Add(product);
        }

        public ICollection<Product> Get()
        {
            return products;
        }

        public Product Get(int id)
        {
            return products.Single(p => p.Id == id);  //wyrażenie Linq
        }

        public Product Get(string name)
        {
            //jeśli będzie więcej niż 1 to zwróci wyjątek
            return products.Single(p => p.Name == name);

            //jeśli będzie więcej niż 1 to zwraca pierwwszy element
           // return products.First(p => p.Name == name);
        }

        public void Remove(int id)
        {
            var product = Get(id);
            products.Remove(product);
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
