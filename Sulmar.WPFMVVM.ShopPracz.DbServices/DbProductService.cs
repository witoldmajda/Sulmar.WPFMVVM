using Sulmar.WPFMVVM.ShopPracz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sulmar.WPFMVVM.ShopPracz.Models;

namespace Sulmar.WPFMVVM.ShopPracz.DbServices
{
    public class DbProductService : IProductsService
    {
        private readonly ShopPraczContext context;

        public DbProductService()
        {
            this.context = new ShopPraczContext();

            //umożliwia śledzenie zapytań do bazy danych
            context.Database.Log = Console.WriteLine;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);

            context.SaveChanges();
        }

        public ICollection<Product> Get()
        {
            return context.Products.ToList();
        }

        public Product Get(int id)
        {
            //var product = context.Products.Find(id); // poszukuje tylko po kluczu

            var product = context.Products.Single(p => p.Id == id); // wyszukiwanie po dowolnie wskazanym atrybucie

            return product;
        }

        public Product Get(string name)
        {
            return context.Products.Single(p => p.Name == name);
        }

        public void Remove(int id)
        {
            var product = Get(id);

            context.Products.Remove(product);

            context.SaveChanges();
        }

        public void Update(Product product)
        {
            context.Entry(product).State = System.Data.Entity.EntityState.Modified; // zmieniamy stan produktu w nowym kontekście na Modified aby context poznał przekazany element

            //var entities = context.ChangeTracker.Entries().ToList(); //element do przeglądu co się dzieje w StateMenagerem

            context.SaveChanges();
        }
    }
}
