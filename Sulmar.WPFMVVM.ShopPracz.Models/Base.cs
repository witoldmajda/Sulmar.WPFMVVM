using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Models
{
    //klasa po której można dziedziczyć

    public abstract class Base : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propName = "") //pobiera atrybut kto mnie wywołał, nie trzeba podawać nazwy kontrolki która wywołała
        {
            if(PropertyChanged != null) //sprawdzamy czy jakiś obiekt słucha
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName)); //informujemy metodę która nasłuchuje
            }
        }
    }

}
