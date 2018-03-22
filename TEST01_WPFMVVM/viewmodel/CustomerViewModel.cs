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

            Load();

            //Customers = new ObservableCollection<CustomerModel>(_CustomersService.Get());  //implementacja klasy informującej listę o konieczności zmiany
            

        }

        public CustomerViewModel()
            :this(new MocCustomersServices()) //używamy gdy kożystamy z Moc
        {

        }

        private void Load()
        {
            Customers = new ObservableCollection<CustomerModel>(_CustomersService.Get());  //implementacja klasy informującej listę o konieczności zmiany
            //pobranie listy z bazy np Moc
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

       
        private ICommand _UpdateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                return new RelayCommand(p => Update(), p => CanUpdate());
                

            }
            set { _UpdateCommand = value; }
        }

        private void Update()
        {
            _CustomersService.Update(SelectedCustomer);
        }

        private bool CanUpdate()
        {
           // return IsSelectedCustomer && !Customers.Any(c => c.Name == SelectedCustomer.Name); // można za pomocą zapytań Linq odpytać pobraną kolekcję produktów pod kątem walidacji działań na bazie danych
            return IsSelectedCustomer;
        }

        public ICommand AddCommand
        {
            get
            {
                return new RelayCommand(c => Add());
            }
        }

        public void Add()
        {
            var customer = new CustomerModel(Customer.Name);
            _CustomersService.Add(customer);
            //_CustomersService.Add(customer);
            this.Customers.Add(customer);
        }


        public ICommand RemoveCommand
        {
            get
            {
                return new RelayCommand(c => Remove(), c => CanRemove());
            }
        }

        private bool IsSelectedCustomer => SelectedCustomer != null;
            

        public CustomerModel SelectedCustomer { get; set; }

        private bool CanRemove()
        {
            return IsSelectedCustomer;
        }

        private void Remove()
        {
            _CustomersService.Remove(SelectedCustomer.Id);
            this.Customers.Remove(SelectedCustomer);
        }
    }
}
