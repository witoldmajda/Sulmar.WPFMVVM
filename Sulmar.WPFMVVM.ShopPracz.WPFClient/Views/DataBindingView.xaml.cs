using Sulmar.WPFMVVM.ShopPracz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sulmar.WPFMVVM.ShopPracz.WPFClient.Views
{
    /// <summary>
    /// Interaction logic for DataBindingView.xaml
    /// </summary>
    public partial class DataBindingView : Window
    {
        public DataBindingView()
        {
            InitializeComponent();

            var product = new Product { Id = 1, Name = "Product 1", Color = "Red" };

            this.DataContext = product;
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = this.DataContext as Product;
            product.Price = 99;
            product.Color = "Black";
        }
    }
}
