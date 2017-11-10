using Sulmar.WPFMVVM.Common4;
using Sulmar.WPFMVVM.ShopPracz.DbServices;
using Sulmar.WPFMVVM.ShopPracz.Models;
using Sulmar.WPFMVVM.ShopPracz.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sulmar.WPFMVVM.ShopPracz.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private ICollection<Product> _products;
        public ICollection<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public Product SelectedProduct { get; set; }


        private readonly IProductsService productsService;

        public ProductsViewModel(IProductsService productsService)
        {
            this.productsService = productsService;

            Load();
        }

        public ProductsViewModel()
            //: this(new MockProductService()) // gdy kożystamy z Moc używamy metod Moc
            : this(new DbProductService()) // gdy kożystamy z bazy danych kożystamy z metod klasy DbProductService
        {
            
        }

        private void Load()
        {
            Products = new ObservableCollection<Product>(productsService.Get());  //implementacja klasy informującej listę o konieczności zmiany
        }

        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(p => Add());
            }
        }

        private void Add()
        {
            var product = new Product { Name = "Product 6", Color = "Red", Price = 66.6m, Size = "L" };

            productsService.Add(product);
            this.Products.Add(product);
        }

        public ICommand RemoveCommand
        {
            get
            {
                return new RelayCommand(p => Remove(), p => CanRemove());
            }
        }

        private bool CanRemove()
        {
            return IsSelectedProduct;
        }

        private bool IsSelectedProduct => SelectedProduct != null;

        private void Remove()
        {
            productsService.Remove(SelectedProduct.Id);
            this.Products.Remove(SelectedProduct);
        }

        public ICommand UpdateCommand
        {
            get
            {
                return new RelayCommand(p => Update(), p => CanUpdate());
            }
        }


        private void Update()
        {
            productsService.Update(SelectedProduct);
            
        }

        private bool CanUpdate()
        {
            //return IsSelectedProduct && !Products.Any(p => p.Name == SelectedProduct.Name); // można za pomocą zapytań Linq odpytać pobraną kolekcję produktów pod kątem walidacji działań na bazie danych
            return IsSelectedProduct;
        }
    }
}
