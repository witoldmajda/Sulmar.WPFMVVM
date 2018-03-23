﻿using System;
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
using TEST01_WPFMVVM.services;

namespace TEST01_WPFMVVM.viewmodel
{
    public class CustomerViewModel : BaseViewModel
    {
        private readonly ICustomersService _CustomersService;

        public CustomerViewModel(ICustomersService _CustomersService)
        {
            this._CustomersService = _CustomersService;

             _Customer = new CustomerModel("Witek");
            this.IsEnabled = false;

            //Customers = new ObservableCollection<CustomerModel>(_CustomersService.Get());  //implementacja klasy informującej listę o konieczności zmiany
            Load();

        }

        public CustomerViewModel()
            : this(new MocCustomersServices()) // gdy kożystamy z Moc używamy metod Moc
            //: this(new DbProductService()) // gdy kożystamy z bazy danych kożystamy z metod klasy DbProductService
        {

        }


        private void Load()
        {
            Customers = new ObservableCollection<CustomerModel>(_CustomersService.Get());  //implementacja klasy informującej listę o konieczności zmiany
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
            //return IsSelectedCustomer; 
            return this.IsEnabled;
        }
        

        private ICommand _UpdateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                return new RelayCommand(p => Update(), p => CanUpdate());
                

            }
            set { _UpdateCommand = value; }
        }



        public void Update()
        {
            _CustomersService.Update(SelectedCustomer);
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
            _CustomersService.Add(customer);
            this.Customers.Add(customer);
        }

        public ICommand RemoveCommand
        {
            get
            {
                return new RelayCommand(c => Remove(), c => CanRemove());
            }
        }

        private bool CanRemove()
        {
            //return IsSelectedCustomer;
            return this.IsEnabled;
        }

        //private bool IsSelectedCustomer => SelectedCustomer != null;
       // private bool IsSelectedCustomer;
        

        private CustomerModel _SelectedCustomer;

        public CustomerModel SelectedCustomer
        {
            get
            {
                return _SelectedCustomer;                
            }
            set
            {
                if (_SelectedCustomer != value)
                {
                    _SelectedCustomer = value;
                    OnPropertyChanged();
                   // IsSelectedCustomer = true;
                    this.IsEnabled = true;
                    if (_SelectedCustomer == null)
                    {
                        this.IsEnabled = true;
                        //this.IsSelectedCustomer = true;
                    }
                }
            }
        }

        private bool _IsEnabled;
        public bool IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            set
            {
                _IsEnabled = value;
                OnPropertyChanged();

            }
        }

        private void Remove()
        {
            _CustomersService.Remove(SelectedCustomer.Id);
            this.Customers.Remove(SelectedCustomer);
        }
    }
}
