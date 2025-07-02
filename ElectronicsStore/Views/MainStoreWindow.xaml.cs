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
        private bool _isMaximized = false;
        private string _username;

        public MainStoreWindow(string username)
        {
            InitializeComponent();
            _username = username;
            this.Loaded += (s, e) =>
            {
                ProductsButton_Click(null, null);

            };



            this.MouseLeftButtonDown += (s, e) =>
            {
                if (e.GetPosition(this).Y <= 60)DragMove();
                if (e.ClickCount == 2 && e.GetPosition(this).Y <= 60)ToggleMaximize();
            };
        }






        private void ActivateButton(Button button)
        {

            if (ProductsButton == null || CartButton == null) return;
            var productsUnderline = (Rectangle)ProductsButton.Template?.FindName("underline", ProductsButton);
            var cartUnderline = (Rectangle)CartButton.Template?.FindName("underline", CartButton);
            if (productsUnderline != null) productsUnderline.Opacity = button == ProductsButton ? 1 : 0;

            if (cartUnderline != null)cartUnderline.Opacity = button == CartButton ? 1 : 0;


        }

        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
            ActivateButton(ProductsButton);
            MainFrame.Navigate(new ProductsView(_username));
        }
        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            ActivateButton(CartButton);
            MainFrame.Navigate(new CartView(_username));
        }



        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }



        private void ToggleMaximize()
        {
            _isMaximized = !_isMaximized;

            if (_isMaximized)
            {
                WindowState = WindowState.Maximized;
                MaximizeButton.Content = "❒";
                Margin = new Thickness(0);
            }
            else
            {
                WindowState = WindowState.Normal;
                MaximizeButton.Content = "□";
                Margin = new Thickness(10);
            }



        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleMaximize();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
