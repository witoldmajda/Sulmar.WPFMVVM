using Sulmar.WPFMVVM.Common;
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
    public class OrdersViewModel : BaseViewModel
    {
       // public ICollection<Order> Orders { get; set; } // właściwość z listą zamówień do której podpina się projekt

        public ICollection<Order> Orders { get; set; }

        //public Order SelectedOrder { get; set; }

        private Order _selectedOrder;

        public Order SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                GetOrderDetailsOfSelectedOrders();
            }
        }



        private IOrdersService ordersService;

        private IOrderDetailsService orderDetailsService;

        public OrdersViewModel()
            : this(new MockOrdersService(), new MocOrderDetailsService())   
        {
            // konstruktor wywoływany w momencie  gdy nie będzie podany orderService, taka notacja pozwala wywołanie następnego konstruktora
        }
        public OrdersViewModel(IOrdersService ordersService, IOrderDetailsService orderDetailsService) //do konstruktora 
        {
            //ordersService = new MockOrdersService();  alternatywa do Wejścia ordersService podawanego do konstruktora

            this.ordersService = ordersService;
            this.orderDetailsService = orderDetailsService;
            Load();
        }

        private void Load()
        {
            Orders = ordersService.Get();  //ładowanie listy zamówień poprzez interfejs i zwracanie tej listy do właściwości Orders
        }

        private void GetOrderDetailsOfSelectedOrders()
        {
            SelectedOrder.Details = orderDetailsService.Get(SelectedOrder.Id);
        }

        public ICommand CalculateCommand
        {
            get
            {
                return new RelayCommand(p => Calculate(p), p => CanCalculate(p));
            }
        }

        private void Calculate(object p)
        {
            Console.WriteLine($"Selected item{this.SelectedOrder.Number}");
        }

        private bool CanCalculate(object p)
        {
            return this.SelectedOrder!=null;
        }

       
    }
}
