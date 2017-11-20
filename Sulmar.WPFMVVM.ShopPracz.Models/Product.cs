using System;
using System.Collections.Generic;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Models
{
    public class Product : Base
    {
        public int Id { get; set; }

      

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();

            }
        }



        private string _color;

        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged();
            }
        }


        private decimal _price;

        public decimal Price
        {
            get { return _price; }
            set
            {                
                _price = value;

                OnPropertyChanged(); // informuje widok o zmianie
            }
        }

        public string Size { get; set; }

       // public float Weight { get; set; }

        public Product()
        {
            this.Color = "Blue";
            this.Name = "Nazwa produktu";
        }




    }
}
