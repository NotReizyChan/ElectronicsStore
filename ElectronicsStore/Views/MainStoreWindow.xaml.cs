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
using System.IO;


namespace ElectronicsStore.Views
{
    /// <summary>
    /// Логика взаимодействия для MainStoreWindow.xaml
    /// </summary>
    public partial class MainStoreWindow : Window
    {
        private string _username;




        public MainStoreWindow(string username)
        {
            InitializeComponent();
            //    ProductsButton.Click += (s, e) => MainFrame.Navigate(new ProductsView(username));
            //    CartButton.Click += (s, e) => MainFrame.Navigate(new CartView(username));
            _username = username;
            MainFrame.Navigate(new ProductsView(_username));
        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsView(_username));
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CartView(_username));
        }
    }
}
