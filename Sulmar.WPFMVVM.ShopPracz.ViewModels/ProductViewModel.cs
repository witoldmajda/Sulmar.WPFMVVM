using Sulmar.WPFMVVM.Common4;
using Sulmar.WPFMVVM.ShopPracz.DbServices;
using Sulmar.WPFMVVM.ShopPracz.Models;
using Sulmar.WPFMVVM.ShopPracz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sulmar.WPFMVVM.ShopPracz.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public Product Product { get; set; }

        private readonly IProductsService productsService;

        //public ProductViewModel()
        //    : this(new DbProductsService())
        //{
        //}

        public ProductViewModel(IProductsService productsService)
        {
            this.productsService = productsService;

            this.Product = new Product();

        }


    }
}
