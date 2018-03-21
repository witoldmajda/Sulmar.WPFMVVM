using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TEST01_WPFMVVM.model;
using TEST01_WPFMVVM.Commands;
using System.Windows;
using System.Collections.ObjectModel;
using TEST01_WPFMVVM.interfaces;

namespace TEST01_WPFMVVM.viewmodel
{
    public class CustomerViewModel : BaseViewModel
    {
        //private readonly ICustomersService _CustomersService;

        public CustomerViewModel()
        {
            //this._CustomersService = _CustomersService;

            _Customer = new CustomerModel("Witek");

            //Customers = new ObservableCollection<CustomerModel>(_CustomersService.Get());  //implementacja klasy informującej listę o konieczności zmiany
            Customers = new ObservableCollection<CustomerModel>();  //implementacja klasy informującej listę o konieczności zmiany

        }

        private ICollection<CustomerModel> _Customers;   

        public ICollection<CustomerModel> Customers
        {
            get { return _Customers; }
            set
            {
                _Customers = value;
                OnPropertyChanged();
            }
        }

       


        private CustomerModel _Customer;

        public CustomerModel Customer
        {
            get { return _Customer; }
            set
            {
                _Customer = value;
                OnPropertyChanged();
            }
        }

        private bool CanUpdate()
        {
            return true;            
        }




        private ICommand _UpdateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                return new RelayCommand(p => SaveChanges(), p => CanUpdate());
                

            }
            set { _UpdateCommand = value; }
        }



        public void SaveChanges()
        {
            MessageBox.Show("update");
        }


        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(p => Add());
            }
        }

        public void Add()
        {
            var customer = new CustomerModel(Customer.Name);
            //_CustomersService.Add(customer);
            this.Customers.Add(customer);
        }
    }
}
