using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Models
{
    public class Order : Base
    {
        public Order()
        {
            Details = new List<OrderDetail>(); // inicjuniemy pustą kolekcję detali aby działała metoda sumująca detale
        }

        public int Id { get; set; }

        public string Number { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public Customer Customer { get; set; }

        private ICollection<OrderDetail> _details;

        public ICollection<OrderDetail> Details
        {
            get
            {
                return _details;
            }
            set
            {
                _details = value;
                foreach(var detail in Details)
                {
                    detail.PropertyChanged += Detail_PropertyChanged; // jeśli zdarzenie wystąpi to wywołuje metodę Detail_PropertyChanged
                }
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        private void Detail_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Amount")
            {
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return Details.Sum(detail => detail.Amount); //suma kolekcji 
            }
        }

        //public override string ToString() // metoda do wyświetlania elementów z klasy, lepiej wykonać to w widoku
        //{
        //    return $"{Number} {OrderDate}";
        //}
    }

    public enum OrderStatus
    {
        Created,

        Processing,

        Delivered,
    }
}
