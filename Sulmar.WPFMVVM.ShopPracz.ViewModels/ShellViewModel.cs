using Sulmar.WPFMVVM.Common4;
using Sulmar.WPFMVVM.ShopPracz.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sulmar.WPFMVVM.ShopPracz.ViewModels
{
    public class ShellViewModel : BaseViewModel
    {
        #region SelectedViewModel

        private BaseViewModel selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged(); }
        }

        #endregion


        public ShellViewModel()
        {
            SelectedViewModel = new ProductsViewModel();
        }



        #region ShowOrdersCommand

        public ICommand ShowOrdersCommand
        {
            get
            {
                return new RelayCommand(p => ShowOrders());
            }
        }

        private void ShowOrders()
        {
            SelectedViewModel = new OrdersViewModel();
        }

        #endregion

        #region ShowProductsCommand

        public ICommand ShowProductsCommand
        {
            get
            {
                return new RelayCommand(p => ShowProducts());
            }
        }

        private void ShowProducts()
        {
            SelectedViewModel = new ProductsViewModel();
        }

        #endregion
    }
}
