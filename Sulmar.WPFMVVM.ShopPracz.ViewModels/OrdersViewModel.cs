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
    public class OrdersViewModel : BaseViewModel
    {
        // public ICollection<Order> Orders { get; set; } // właściwość z listą zamówień do której podpina się projekt


        private ICollection<Order> _orders;
        public ICollection<Order> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }

        //public Order SelectedOrder { get; set; }

        private Order _selectedOrder;

        public Order SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                
                //wyzwalamy sprawdzenie CanExecute

               // CalculateCommand.OnCanExecuteChanged();

                GetOrderDetailsOfSelectedOrders();
                OnPropertyChanged();


            }
        }



        private readonly IOrdersService ordersService;

        private readonly IOrderDetailsService orderDetailsService;

        public OrdersViewModel()
            //: this(new MockOrdersService(), new MocOrderDetailsService())   //gdy używamy Mocków
            : this(new DbOrdersService(), new MocOrderDetailsService())  //gdy używamy bazy danych
        {
            // konstruktor wywoływany w momencie  gdy nie będzie podany orderService, taka notacja pozwala wywołanie następnego konstruktora
        }
        public OrdersViewModel(IOrdersService ordersService, IOrderDetailsService orderDetailsService) //do konstruktora 
        {
            //ordersService = new MockOrdersService();  alternatywa do Wejścia ordersService podawanego do konstruktora

            this.ordersService = ordersService;
            this.orderDetailsService = orderDetailsService;
            //Load(); zamiennie lepiej wywoływać za pomocą zdarzenia LoadCommand
        }

        public RelayCommand LoadCommand 
        {
            get
            {
                return new RelayCommand(p => Load()); 
            }
        }

        private void Load()
        {
            Orders = ordersService.Get();  //ładowanie listy zamówień poprzez interfejs i zwracanie tej listy do właściwości Orders
        }

        private void GetOrderDetailsOfSelectedOrders()
        {
            SelectedOrder.Details = orderDetailsService.Get(SelectedOrder.Id);
        }

        public RelayCommand CalculateCommand
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
            return this.SelectedOrder!=null && SelectedOrder.Status == OrderStatus.Created;
        }

       
    }
}
